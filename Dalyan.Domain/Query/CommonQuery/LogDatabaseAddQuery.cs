//------------------------------------------------------------------------------
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
    
    public class LogDatabaseAddQuery : IQuery<Dalyan.Entities.Models.LogDatabase>
    {
    	public Dalyan.Entities.Models.LogDatabase LogDatabase{ get; set; }
    }
    
    public class LogDatabaseAddQueryHandler : IQueryHandler<LogDatabaseAddQuery,Dalyan.Entities.Models.LogDatabase>
    {
    	private readonly DbEntities _db;
    	public LogDatabaseAddQueryHandler()
    	{
    		_db = new DbEntities();
    	}
    
    	    
    	public Dalyan.Entities.Models.LogDatabase Handler(LogDatabaseAddQuery query)
    	{
    		try
    		{
    			var obj = new Dalyan.Db.LogDatabase();
    			obj.Id = query.LogDatabase.Id;
    			obj.UserId = query.LogDatabase.UserId;
    			obj.LogDate = query.LogDatabase.LogDate;
    			obj.LogType = query.LogDatabase.LogType;
    			obj.LogLevel = query.LogDatabase.LogLevel;
    			obj.ExceptionString = query.LogDatabase.ExceptionString;
    			obj.Comment = query.LogDatabase.Comment;
    			obj.IsDeleted = query.LogDatabase.IsDeleted;
    			_db.LogDatabase.Add(obj);
    			_db.SaveChanges();
    			query.LogDatabase.Id = obj.Id;
    			return query.LogDatabase;
    
    		}
    		catch (Exception ex)
    		{
    			throw new ExceptionLog(LogType.DATABASE_INSERT, LogLevel.ERROR, ex, "AddQueryHandler");
    		}
    	}
    }
    
    
}
