using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Dalyan.WebApi.Security
{
    public class Identity : IIdentity
    {
        private string _name;
        private string _email;
        private int _userID;
        private int _userType;
        private int _companyId;
        private string _companyName;
        private string _ipaddress;

        public Identity(string name, int userID, string email, int userType,int companyId, string companyName, string ipaddress)
        {
            _userID = userID;
            _email = email;
            _name = name;
            _userType = userType;
            _companyId = companyId;
            _companyName = companyName;
            _ipaddress = ipaddress;
        }

        public int UserID
        {
            get { return _userID; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string AuthenticationType
        {
            get { return "Bearer"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int UserType
        {
            get { return _userType; }
        }

        public int CompanyId
        {
           get { return _companyId; }
        }

        public string CompanyName
        {
            get { return _companyName; }
        }

        public string IpAddress
        {
            get { return _ipaddress; }
        }
    }
}