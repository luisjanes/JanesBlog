using Dapper.Contrib.Extensions;
using JanesBlog.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanesBlog.Repositories
{
    public class Repository<T> where T:class 
    {
        private readonly MySqlConnection _connection;
        public Repository(MySqlConnection connection) 
            => _connection = connection;

        public IEnumerable<T> GetAll()
            => _connection.GetAll<T>();

        public T Get(int id)
            => _connection.Get<T>(id);

        public void Create(T model)
            => _connection.Insert<T>(model);

        public void Update(T model)
            => _connection.Update<T>(model);

        public void Delete(T model)
            => _connection.Delete<T>(model);
        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}
