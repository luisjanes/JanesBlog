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
    public class UserRepository(MySqlConnection connection)
    {
        private readonly MySqlConnection _connection = connection;

        public IEnumerable<User> Get()
            => _connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void Create(User user)
            => _connection.Insert<User>(user);
    }
}
