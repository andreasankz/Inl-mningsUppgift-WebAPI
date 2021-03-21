using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
