using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GestionFacturation.Api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GestionFacturation.Api.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string AuthorizationHeaderKey = "Authorization";

        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, 
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }


        /// <summary>
        ///     Authentifiziert den Aufrufenden und legt seine Claims fest.
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(AuthorizationHeaderKey))
                return AuthenticateResult.Fail("Missing Authorization Header");

            User user;

            try
            {
                var (username, password) = GetCredentialsFromHeader();
                user = await _userService.Authenticate(username, password);

                if (user == null)
                    return AuthenticateResult.Fail("Invalid Username or Password");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = ResolveUserClaims(user);
            var ticket = CreateUserTicket(claims);

            // Abfahrt!
            return AuthenticateResult.Success(ticket);
        }

        private (string username, string password) GetCredentialsFromHeader()
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[AuthorizationHeaderKey]);
            var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter));
            var credentials = credentialString.Split(':');

            var username = credentials[0];
            var password = credentials[1];

            return (username, password);
        }

        private IEnumerable<Claim> ResolveUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.ApiAccessLevels.HasFlag(ApiAccessLevels.Technicien))
                claims.Add(new Claim(ClaimTypes.Role, Roles.Technicien));

            if (user.ApiAccessLevels.HasFlag(ApiAccessLevels.Admin)) 
                claims.Add(new Claim(ClaimTypes.Role, Roles.Admin));
                
            return claims;
        }

        private AuthenticationTicket CreateUserTicket(IEnumerable<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return ticket;
        }
    }
}