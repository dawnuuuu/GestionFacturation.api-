using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GestionFacturation.Api.Auth
{
    public static class SwaggerBasicAuth
    {
        public static void AddSwaggerBasicAuth(this SwaggerGenOptions instance)
        {
            instance.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
            {
                Description = "Input username and password.",
                Name = BasicAuthenticationHandler.AuthorizationHeaderKey,
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Scheme = "basic"
            });

            instance.OperationFilter<AuthenticationRequirementsOperationFilter>();
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class AuthenticationRequirementsOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();


                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basicAuth"
                    }
                };

                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
            }
        }
    }
}