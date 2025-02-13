using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Shared.Models.User
{
    public class LoginRequest
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}