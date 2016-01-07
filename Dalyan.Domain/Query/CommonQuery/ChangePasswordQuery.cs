namespace Dalyan.Domain.Query
{
    using System;
    using Dalyan.Domain;
    using System.Linq;
    using System.Text;
    using Dalyan.Domain.Query;
    using System.Data;
    using System.Xml;
    using Dalyan.Db;
    using Entities.Models;
    using Dalyan.Entities.Enumerations;
    using AutoMapper;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ChangePasswordQuery : IQuery<bool>
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordQueryHandler : IQueryHandler<ChangePasswordQuery, bool>
    {
        private readonly DbEntities _db;
        public ChangePasswordQueryHandler()
        {
            _db = new DbEntities();
        }


        public bool Handler(ChangePasswordQuery query)
        {
            try
            {
                var obj = new Dalyan.Db.User();
                obj = _db.User.FirstOrDefault(x => x.Id == query.Id);
                obj.Password = query.Password;
                obj.UpdatedDate = DateTime.Now;
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new ExceptionLog(LogType.DATABASE_UPDATE, LogLevel.ERROR, ex, "ChangePasswordQuery");
            }
        }
    }

}
