using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Dalyan.Entities.Models;
using Dalyan.Domain.Query;
using Dalyan.Domain;

namespace Dalyan.Service.Services
{
    public class Test
    {
        private readonly Container _container;
        public Test(Container container)
        {
            _container = container;
        }

        public User Add(User obj)
        {
            IMediator service = _container.GetInstance<IMediator>();
            var query = new UserAddQuery();
            query.User = obj;
            return service.Proccess(query);
        }
        
        public User Edit(User obj)
        {
            IMediator service = _container.GetInstance<IMediator>();
            var query = new UserEditQuery();
            query.User = obj;
            return service.Proccess(query);
        }

        public User Retrieve(int Id)
        {
            IMediator service = _container.GetInstance<IMediator>();
            var query = new UserRetrieveQuery{
                Id = Id
            };
            return service.Proccess(query);
        }
        public IList<User> GetAll()
        {
            IMediator service = _container.GetInstance<IMediator>();
            var query = new UserGetAllQuery();
            return service.Proccess(query);
        }
        

        public bool Delete(int Id)
        {
            IMediator service = _container.GetInstance<IMediator>();
            var query = new UserDeleteQuery{
                Id = Id
            };
            return service.Proccess(query);
        }

    }
}
