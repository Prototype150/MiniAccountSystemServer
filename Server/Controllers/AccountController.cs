using DLL.Managers.Interfaces;
using DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
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
        public async Task<ObjectResult> Register([FromBody]string accountDetailes)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(accountDetailes);

            if (string.IsNullOrWhiteSpace(unAcc.Username))
                return BadRequest("empty:username");
            if (string.IsNullOrWhiteSpace(unAcc.Email))
                return BadRequest("empty:email");
            if (string.IsNullOrWhiteSpace(unAcc.Password))
                return BadRequest("empty:password");

            SecureString password = new SecureString();
            for (int i = 0; i < unAcc.Password.Length; i++)
            {
                password.AppendChar(unAcc.Password[i]);
            }

            string r = _accountManager.Add(new AccountModel { Username = unAcc.Username, Email = unAcc.Email, Password = password });

            if (r == "username" || r == "email")
                return BadRequest(r);

            return Ok(r);
        }

        [HttpGet]
        [Route("login/{loginCredentials}")]
        public async Task<ActionResult> Login(string loginCredentials)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(loginCredentials);

            if (string.IsNullOrWhiteSpace(unAcc.Username))
                return BadRequest("empty:username");
            if (string.IsNullOrWhiteSpace(unAcc.Password))
                return BadRequest("empty:password");

            var acc = _accountManager.GetByUsername(unAcc.Username);

            if (acc == null)
                return BadRequest("login");
            else if (Marshal.PtrToStringUni(Marshal.SecureStringToGlobalAllocUnicode(acc.Password)) != unAcc.Password)
                return BadRequest("password");

            return Ok(acc);
        }
    }
}
