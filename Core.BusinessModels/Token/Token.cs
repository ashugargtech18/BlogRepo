using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessModels.Token
{
    public class Token
    {
        public string Email { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }
    }

    public class Login
    {
        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
