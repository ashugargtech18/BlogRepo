using AutoMapper;
using BlogApi.Contract;
using BlogApi.Contract.Request;
using Core.BusinessModels.Token;
using Core.Interfaces.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Controllers.V1
{
   
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        private readonly IMapper mapper;

        private readonly IConfiguration _config;
        public TokenController(ITokenService service, IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg=> {

                cfg.CreateMap<Core.BusinessModels.Token.Login, LoginRequest>();
                cfg.CreateMap<LoginRequest,Core.BusinessModels.Token.Login>();
            });
            mapper = config.CreateMapper();

            _config = configuration;
           
            tokenService = service;
        }

        /// <summary>
        /// UserName ='abc@123' password='working'
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost(template:ApiRoutes.Token.GetToken)]
        public ActionResult CreateToken([FromBody]LoginRequest login)
        {
          

            ActionResult response = Unauthorized();

            
            var model = mapper.Map<Core.BusinessModels.Token.Login>(login);
            var userdetails = tokenService.GetTokenProfile(model);

            if (userdetails != null)
            {
                response = Ok(BuildToken(userdetails));
            }
            return response;
        }

        private SecurityToken BuildToken(Token user)
        {
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config.GetValue<string>("Jwt:Issuer"), _config.GetValue<string>("Jwt:Issuer"), expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            return new SecurityToken() { AuthToken = new JwtSecurityTokenHandler().WriteToken(token), ApplicationName = "BlogPost" }; 
            
        }

        private class SecurityToken
        { 
           public string AuthToken { get; set; }

           public string ApplicationName { get; set; }
        }

    }
}
