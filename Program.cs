using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using JanesBlog.Models;
using Dapper.Contrib.Extensions;
using JanesBlog.Repositories;
using JanesBlog.Views.UserView;
using JanesBlog.Views;

public class Program
{
    private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;User ID=root; Password=123456";
    public static void Main(string[] args)
    {
        DataBase.Connection = new MySqlConnection(CONNECTION_STRING);
        Load();
    }

    private static void Load()
    {
        Console.WriteLine("Digite 0 para o menu usuários");
        var input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 0:
                MenuUserView.Load();
                break;
            default: Load(); break;
        }
    }
}