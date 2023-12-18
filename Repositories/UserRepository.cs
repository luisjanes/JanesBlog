using Dapper;
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
    public class UserRepository : Repository<User>
    {
        public List<User> ReadWithRole()
        {
            var query = @"
            SELECT
                User.*,
                Role.*
            FROM
                User
                LEFT JOIN UserRole ON UserRole.UserId = User.Id
                LEFT JOIN Role ON UserRole.RoleId = Role.Id";

            var users = new List<User>();
            var items = DataBase.Connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (usr != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
    }
}
