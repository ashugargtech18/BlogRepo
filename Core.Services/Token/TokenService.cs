using AutoMapper;
using Core.BusinessModels.Token;
using Core.Interfaces.Token;
using Domain.DataModels.Token;
using Domain.Interfaces.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly ITokenDataService _tokenDataService;

        private readonly IMapper mapper; 

        public TokenService(ITokenDataService tokenDataService)
        {
            var config = new MapperConfiguration(cfg=> {

                cfg.CreateMap<Core.BusinessModels.Token.Token, TokenModel>();
                cfg.CreateMap<TokenModel,Core.BusinessModels.Token.Token >();
                cfg.CreateMap<LoginModel, Core.BusinessModels.Token.Login>();
                cfg.CreateMap<Core.BusinessModels.Token.Login,LoginModel > ();
            });

            mapper = config.CreateMapper();
            _tokenDataService = tokenDataService;
        }
        public BusinessModels.Token.Token GetTokenProfile(Login loginModel)
        {
            var map = mapper.Map<LoginModel>(loginModel);
            var result = _tokenDataService.GetTokenProfile(map);
            var model = mapper.Map<Core.BusinessModels.Token.Token>(result);
            return model;
        }
    }
}
