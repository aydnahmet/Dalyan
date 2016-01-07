﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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

    public class CompanyEditQuery : IQuery<Dalyan.Entities.Models.Company>
    {
        public Dalyan.Entities.Models.Company Company { get; set; }
    }

    public class CompanyEditQueryHandler : IQueryHandler<CompanyEditQuery, Dalyan.Entities.Models.Company>
    {
        private readonly DbEntities _db;
        public CompanyEditQueryHandler()
        {
            _db = new DbEntities();
        }


        public Dalyan.Entities.Models.Company Handler(CompanyEditQuery query)
        {
            try
            {
                var obj = new Dalyan.Db.Company();
                obj = _db.Company.FirstOrDefault(x => x.Id == query.Company.Id);
                obj.Id = query.Company.Id;
                obj.Name = query.Company.Name;
                obj.IsDeleted = query.Company.IsDeleted;
                _db.SaveChanges();
                return query.Company;

            }
            catch (Exception ex)
            {
                throw new ExceptionLog(LogType.DATABASE_UPDATE, LogLevel.ERROR, ex, "EditQueryHandler");
            }
        }
    }

}