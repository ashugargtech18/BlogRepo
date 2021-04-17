using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Token
{
    public interface ITokenService
    {
        public Core.BusinessModels.Token.Token GetTokenProfile(Core.BusinessModels.Token.Login loginModel);
    }
}
