using Dalyan.Entities.Models;
using Dalyan.Service.Authenticate;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Dalyan.Service.Services;
using Dalyan.Entities.Enumerations;

namespace Dalyan.WebApi.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly Container _container;

        public AuthorizationServerProvider(Container container)
        {
            _container = container;
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            User user = null;
            if (!string.IsNullOrEmpty(context.UserName) && !string.IsNullOrEmpty(context.Password))
            {
                AuthenticateService service = new AuthenticateService(_container);
                LogLoginService loginLogService = new LogLoginService(_container);
                LogLogin logLoginObj = new LogLogin();
                user = service.Authenticate(context.UserName, context.Password);
                if (user != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("name", user.Name));
                    identity.AddClaim(new Claim("email", user.Email));
                    identity.AddClaim(new Claim("userid", user.Id.ToString()));
                    identity.AddClaim(new Claim("usertype", user.UserType.ToString()));
                    identity.AddClaim(new Claim("companyid", user.Company.Id.ToString()));
                    identity.AddClaim(new Claim("companyname", user.Company.Name));
                    identity.AddClaim(new Claim("ipaddress", context.Request.RemoteIpAddress));

                    context.Validated(identity);

                    logLoginObj.LoginLogType = LoginLogType.SUCCESS.ToString();
                    logLoginObj.UserId = user.Id;
                }
                else
                {
                    logLoginObj.LoginLogType = LoginLogType.FAILED.ToString();
                    logLoginObj.Comment = "Başarısız Giriş";
                    logLoginObj.ExceptionString = string.Format("UserName:{0} - Password:{1} ", context.UserName, context.Password);
                }
                logLoginObj.IsDeleted = false;
                logLoginObj.LogDate = DateTime.Now;
                loginLogService.Add(logLoginObj);
            }

            //if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            //{
            //    var user = service.Authenticate(Email, Password);
            //    if (user != null)
            //    {
            //        var authentication = Request.GetOwinContext().Authentication;
            //        var identity = new ClaimsIdentity("Bearer");
            //        identity.AddClaim(new Claim("name", user.Name));
            //        identity.AddClaim(new Claim("email", user.Email));
            //        identity.AddClaim(new Claim("userid", user.Id.ToString()));
            //        identity.AddClaim(new Claim("isadmin", user.UserType.Value == 1 ? "true" : "false"));

            //        AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            //        var currentUtc = new Microsoft.Owin.Infrastructure.SystemClock().UtcNow;
            //        ticket.Properties.IssuedUtc = currentUtc;
            //        ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
            //        var token = Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);

            //        authentication.SignIn(identity);

            //        return token;
            //    }
            //}

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
            }


            return Task.FromResult<object>(null);
        }
    }
}