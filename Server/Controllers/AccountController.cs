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
        [Route("login")]
        public async Task<AccountModel> Get(LoginCredentialsModel loginCredentials)
        {
            return new AccountModel() { Username = loginCredentials.Username, Email = loginCredentials.Username };
        }
    }
}
