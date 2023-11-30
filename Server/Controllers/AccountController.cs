using DLL.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
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
        public async Task<bool> Register([FromBody]string accountDetailes)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(accountDetailes);
            string r = _accountManager.Get();

            return true;
        }

        [HttpGet]
        [Route("login/{loginCredentials}")]
        public async Task<AccountModel> Login(string loginCredentials)
        {
            var unAcc = JsonSerializer.Deserialize<UnsecureAccountModel>(loginCredentials);
            return new AccountModel { Email = "correctemail@gmail.com", Username = unAcc.Username };
        }
    }
}
