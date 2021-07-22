using System;
using System.Collections.Generic;
using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }
    }
}