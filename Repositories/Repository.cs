using Dapper.Contrib.Extensions;
using JanesBlog.Models;
using JanesBlog.Views;
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
        public IEnumerable<T> GetAll()
            => DataBase.Connection.GetAll<T>();

        public T Get(int id)
            => DataBase.Connection.Get<T>(id);

        public void Create(T model)
            => DataBase.Connection.Insert<T>(model);

        public void Update(T model)
            => DataBase.Connection.Update<T>(model);

        public void Delete(T model)
            => DataBase.Connection.Delete<T>(model);
        public void Delete(int id)
        {
            var model = DataBase.Connection.Get<T>(id);
            DataBase.Connection.Delete<T>(model);
        }
    }
}
