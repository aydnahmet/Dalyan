using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Dalyan.WebApi.Security
{
    public class Principal : IPrincipal
    {
        private IIdentity _identity;
        private string[] _roles = new string[] { "Admin", "User", "Client" };

        public Principal(IIdentity identity)
        {
            _identity = identity;
        }

        public IIdentity Identity
        {
            get 
            { 
                return _identity; 
            }
        }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role) || _roles == null)
            {
                return false;
            }

            return _roles.Contains(role, StringComparer.OrdinalIgnoreCase);
        }
    }
}