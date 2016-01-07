using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Dalyan.Entities.Models;
using Dalyan.Domain.Query;
using Dalyan.Domain;
using Dalyan.Entities;

namespace Dalyan.Service.Authenticate
{
    public class AuthenticateService
    {
        private readonly Container _container;
        public AuthenticateService(Container container)
        {
            _container = container;
        }

        public User Authenticate(string Email, string Password)
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                var query = new AuthenticateQuery
                {
                    Email = Email,
                    Password = Password
                };
                return service.Proccess(query);
            }
            catch (ExceptionLog ex)
            {
                throw ex;
            }
        }
    }
}
