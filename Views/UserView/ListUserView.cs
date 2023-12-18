using JanesBlog.Models;
using JanesBlog.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanesBlog.Views.UserView
{
    public class ListUserView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Menu Listar Usuários");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Digite 1 para listar os Usuários");
            Console.WriteLine("Digite 2 para listar os Usuários com roles");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ReadUsers();
                    break;
                case 2:
                    ReadUsersRole();
                    break;
                default: Load(); break;
            }
        }
        public static void ReadUsers()
        {
            Console.Clear();
            var userRepository = new Repository<User>();
            var users = userRepository.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }
        public static void ReadUsersRole()
        {
            var userRepository = new UserRepository();
            var users = userRepository.ReadWithRole();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }
    }
}
