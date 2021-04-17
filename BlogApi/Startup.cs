using Core.Interfaces.Blog;
using Core.Interfaces.Token;
using Core.Services.Blog;
using Core.Services.Token;
using Domain.Interfaces;
using Domain.Interfaces.Blog;
using Domain.Interfaces.Token;
using Infrastructure.Data;
using Infrastructure.Data.Blog;
using Infrastructure.Data.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.WebApi.Exception;

namespace BlogApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(environment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.overrides.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            configuration = builder.Build();
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConnectionDataService, ConnectionDataService>();
            services.AddTransient<IBlogDataService, BlogDataService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ITokenDataService, TokenDataService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
         "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                   new OpenApiSecurityScheme
                   {
                      Reference = new OpenApiReference
                      {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                      },
                   Scheme = "oauth2",
                   Name = "Bearer",
                   In = ParameterLocation.Header,

                },
                  new List<string>()
                }
            });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	        .AddJwtBearer(options =>
	        {
		      options.TokenValidationParameters = new TokenValidationParameters
		    {
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = Configuration["Jwt:Issuer"],
			ValidAudience = Configuration["Jwt:Issuer"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
		    };
	});

			services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c=> {

                c.SwaggerEndpoint("/swagger/v1/swagger.json","Blog Api");
               

            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
