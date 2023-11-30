using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Server.Models
{
    public class LoginCredentialsModel
    {
        public LoginCredentialsModel(string username, SecureString password)
        {
            Username = username;
            Password = password;
        }

        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public SecureString Password { get; set; }
    }
}
