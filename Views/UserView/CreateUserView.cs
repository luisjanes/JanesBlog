using JanesBlog.Models;
using JanesBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanesBlog.Views.UserView
{
    public class CreateUserView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Menu Listar Usuários");
            Console.WriteLine();
            Console.WriteLine();
            User user = new User();
            user.Id = 0;
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
            CreateUser(user);
        }
        public static void CreateUser(User user)
        {
            var repository = new Repository<User>();
            repository.Create(user);
        }
    }
}
