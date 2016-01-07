namespace Dalyan.Domain.Query
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Dalyan.Domain;
    using System.Data;
    using System.Xml;
    using Dalyan.Db;
    using Dalyan.Entities.Enumerations;
    using AutoMapper;
    using Entities.Models;

    public class AuthenticateQuery : IQuery<Dalyan.Entities.Models.User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateQueryHandler : IQueryHandler<AuthenticateQuery, Dalyan.Entities.Models.User>
    {
        private readonly DbEntities _db;
        public AuthenticateQueryHandler()
        {
            _db = new DbEntities();
        }


        public Dalyan.Entities.Models.User Handler(AuthenticateQuery query)
        {
            try
            {
                var result = _db.User.Include("Company").Where(x => x.IsDeleted == false && x.Email == query.Email && x.Password == query.Password).FirstOrDefault();
                Mapper.CreateMap<Dalyan.Db.CommonUserType, Dalyan.Entities.Models.CommonUserType>();
                Mapper.CreateMap<Dalyan.Db.Company, Dalyan.Entities.Models.Company>();
                Mapper.CreateMap<Dalyan.Db.User, Dalyan.Entities.Models.User>().ForMember(c => c.CommonUserType, d => d.MapFrom(s => s.CommonUserType)).ForMember(c => c.User2, d => d.MapFrom(s => s.User2)).ForMember(c => c.User3, d => d.MapFrom(s => s.User3)).ForMember(c => c.Company, d => d.MapFrom(s => s.Company));
                return Mapper.Map<Dalyan.Db.User, Dalyan.Entities.Models.User>(result);
            }
            catch (Exception ex)
            {
                throw new ExceptionLog(LogType.DATABASE_SELECT, LogLevel.ERROR, ex, "AuthenticateQueryHandler");
            }
        }
    }
}

