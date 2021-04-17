using Dapper;
using Domain.DataModels.Token;
using Domain.Entities.Resources;
using Domain.Interfaces;
using Domain.Interfaces.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Token
{
    public class TokenDataService : ITokenDataService
    {
        private readonly IConnectionDataService _connectionDataService;

        public TokenDataService(IConnectionDataService connectionDataService)
        {
            _connectionDataService = connectionDataService;
        
        }
        public TokenModel GetTokenProfile(LoginModel login)
        {
            return _connectionDataService.GetConnection.QuerySingle<TokenModel>(SqlObjectReferences.GetTokenProfile, login, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
