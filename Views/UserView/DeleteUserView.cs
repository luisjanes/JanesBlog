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
    public class DeleteUserView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Menu Listar Usuários");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Digite o Id que deseja modificar");
            int id = int.Parse(Console.ReadLine());
            var userRepository = new Repository<User>();
            var userGet = userRepository.Get(id);
            Console.WriteLine($"{userGet.Id} - {userGet.Name} - {userGet.Email} - {userGet.PasswordHash} - {userGet.Bio} - {userGet.Image} - {userGet.Slug}");
            Console.WriteLine("Confirma que quer apagar este usuário?");
            Console.WriteLine("1 para sim");
            Console.WriteLine("2 para não");
            var confirmation = int.Parse(Console.ReadLine());
            if (confirmation == 1)
            {
                DeleteUser(id);
            }
            else
            {
                Load();
            }
        }
        public static void DeleteUser(int id)
        {
            var repository = new Repository<User>();
            repository.Delete(id);
        }
    }
}
