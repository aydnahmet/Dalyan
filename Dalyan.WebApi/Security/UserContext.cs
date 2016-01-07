using Dalyan.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dalyan.WebApi.Security
{
    public class UserContext : Dalyan.Entities.Interfaces.IUserContext
    {
        public bool IsLogged
        {
            get
            {
                if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated
                && HttpContext.Current.User.GetType() != typeof(Principal))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public CurrentUser CurrentUserIdentity
        {
            get
            {
                if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    //&& HttpContext.Current.User.GetType() != typeof(Principal))
                    //System.Security.Claims.ClaimsIdentity claimsIdentity = ((System.Security.Claims.ClaimsIdentity)System.Threading.Thread.CurrentPrincipal.Identity);

                    string name = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).Name;
                    string email = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).Email;
                    int userID = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).UserID;
                    int userType = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).UserType;
                    int companyId = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).CompanyId;
                    string companyName = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).CompanyName;
                    string ipaddress = ((Dalyan.WebApi.Security.Identity)System.Threading.Thread.CurrentPrincipal.Identity).IpAddress;

                    return new CurrentUser { Name = name,  Email = email , UserID = userID , UserType = userType, CompanyId = companyId, CompanyName = companyName, IpAddress = ipaddress };
                }
                else
                {
                    return null;
                }
            }            
        }
    }
}
