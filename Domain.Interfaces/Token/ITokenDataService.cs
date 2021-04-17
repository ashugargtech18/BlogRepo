using Domain.DataModels.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Token
{
    public interface ITokenDataService
    {
        public TokenModel GetTokenProfile(LoginModel loginModel);
        
    }
}
