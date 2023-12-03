using DLL.Managers.Interfaces;
using DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Text.Json;

namespace Server.Controllers
{
    [Route("ac")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        private class UnsecureAccountModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        [HttpPost]
        [Route("register")]
        public async Task<OkObjectResult> Register([FromBody]string accountDetailes)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(accountDetailes);

            SecureString password = new SecureString();
            for (int i = 0; i < unAcc.Password.Length; i++)
            {
                password.AppendChar(unAcc.Password[i]);
            }

            bool r = _accountManager.Add(new AccountModel { Username = unAcc.Username, Email = unAcc.Email, Password = password });

            return Ok(r);
        }

        [HttpGet]
        [Route("login/{loginCredentials}")]
        public async Task<OkObjectResult> Login(string loginCredentials)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(loginCredentials);

            var acc = _accountManager.GetByUsername(unAcc.Username);

            if (acc == null)
                throw new Exception("acc");

            return Ok(acc);
        }
    }
}
