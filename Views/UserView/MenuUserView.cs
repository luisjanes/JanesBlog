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

    public static class MenuUserView
    {

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para listar os Usuários");
            Console.WriteLine("Digite 2 para adicionar um usuário");
            Console.WriteLine("Digite 3 para modificar um usuário");
            Console.WriteLine("Digite 4 para deletar um usuário");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ListUserView.Load();
                    break;
                case 2:
                    CreateUserView.Load();
                    break;
                case 3:
                    UpdateUserView.Load();
                    break;
                case 4:
                    DeleteUserView.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
