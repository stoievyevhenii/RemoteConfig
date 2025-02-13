using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConfig.Shared.Models.User
{
    public class LoginResponseModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
    }
}