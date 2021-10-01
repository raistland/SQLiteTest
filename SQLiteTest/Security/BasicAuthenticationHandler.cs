using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SQLiteTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SQLiteTest.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        private readonly DataContext context;
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> options,
                                           ILoggerFactory logger,
                                           UrlEncoder urlEncoder,
                                           ISystemClock systemClock,
                                           DataContext context) : base(options, logger, urlEncoder, systemClock)
        {
            this.context = context;

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {

                return Task.FromResult(AuthenticateResult.NoResult());

            }

            byte[] headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            string usernamePassword = Encoding.UTF8.GetString(headerValueBytes);
            string[] parts = usernamePassword.Split(':');
            string username = parts[0];
            string password = parts[1];

            User user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Bilgiler Hatalı"));
            }

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.IsAdmin ? "Admin" : "EndUser" )
            };


            ClaimsIdentity identity = new(claims, Scheme.Name);
            ClaimsPrincipal principal = new(identity);


            AuthenticationTicket ticket = new(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
