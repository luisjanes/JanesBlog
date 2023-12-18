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
    public class UpdateUserView
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
            User user = new User();
            Console.WriteLine("Digite as informações que deseja alterar");
            Console.WriteLine("Insira o ID");
            user.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o Nome");
            user.Name = Console.ReadLine();
            Console.WriteLine("Insira o Email");
            user.Email = Console.ReadLine();
            Console.WriteLine("Insira o Hash");
            user.PasswordHash = Console.ReadLine();
            Console.WriteLine("Insira a bio");
            user.Bio = Console.ReadLine();
            user.Image = "https://";
            Console.WriteLine("Insira o Slug");
            user.Slug = Console.ReadLine();
            Console.WriteLine($"{user.Id} - {user.Name} - {user.Email} - {user.PasswordHash} - {user.Bio} - {user.Image} - {user.Slug}");
            Console.WriteLine("Confirma as informações?");
            Console.WriteLine("1 para sim");
            Console.WriteLine("2 para não");
            var confirmation = int.Parse(Console.ReadLine());
            if (confirmation == 1) 
            {
                UpdateUser(user);
            } else
            {
                Load();
            }

        }
        public static void UpdateUser(User user)
        {
            var repository = new Repository<User>();
            repository.Update(user);
        }
    }
}
