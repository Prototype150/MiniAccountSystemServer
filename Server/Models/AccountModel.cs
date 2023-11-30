using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Server.Models
{
    public class AccountModel : LoginCredentialsModel
    {
        public AccountModel(string username = "", SecureString password = null, string email = ""):base(username, password)
        {
            Email = email;
        }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}