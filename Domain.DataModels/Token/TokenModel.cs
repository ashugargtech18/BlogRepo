using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataModels.Token
{
    public class TokenModel
    {
        public string Email { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }
    }

    public class LoginModel 
    { 
        public string UserName { get; set; }

        public string Password { get; set; }
    
    }
}
