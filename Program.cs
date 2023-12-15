using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using JanesBlog.Models;
using Dapper.Contrib.Extensions;
using JanesBlog.Repositories;

public class Program
{
    private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;User ID=root; Password=123456";
    public static void Main(string[] args)
    {
        var connection = new MySqlConnection(CONNECTION_STRING);
        ReadUsers(connection);
        //ReadRoles(connection);
        //ReadUser(connection);
        //CreateUser(connection);
        //UpdateUser(connection);
        //DeleteUser(connection);
    }
    public static void ReadUsers(MySqlConnection connection)
    {
        var userRepository = new Repository<User>(connection);
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
    public static void ReadRoles(MySqlConnection connection)
    {
        var roleRepository = new Repository<Role>(connection);
        var roles = roleRepository.GetAll();
        foreach (var role in roles)
            Console.WriteLine(role.Name);
    }
    public static void ReadUser(MySqlConnection connection, int id)
    {
        var user = connection.Get<User>(id);
        Console.WriteLine(user.Name);
        Console.WriteLine(user.Email);
    }
    public static void ReadRole(MySqlConnection connection, int id)
    {
        var role = connection.Get<Role>(id);
        Console.WriteLine(role.Name);
        Console.WriteLine(role.Email);
    }
    public static void CreateUser(MySqlConnection connection)
    {
        var user = new User()
        {
            Id = 0,
            Name = "Mariane",
            Email = "mariane@gmail.com",
            PasswordHash = "HASH",
            Bio = "A Grande Mariane",
            Image = "https://",
            Slug = "mariane"
        };
        var repository = new Repository<User>(connection);
        repository.Create(user);
    }
    public static void CreateRole(MySqlConnection connection)
    {
        var role = new Role()
        {
            Id = 0,
            Name = "ADM",
            Slug = "adm"
        };
        var repository = new Repository<Role>(connection);
        repository.Create(role);
    }
    public static void UpdateUser(MySqlConnection connection)
    {
        var user = new User()
        {
            Id = 2,
            Name = "Carolina",
            Email = "carolina2@gmail.com",
            PasswordHash = "HASH",
            Bio = "A Grande Carolina",
            Image = "https://",
            Slug = "carolina2"
        };
        var repository = new Repository<User>(connection); 
        repository.Update(user);
    }
    public static void DeleteUser(MySqlConnection connection, int id)
    {
        var repository = new Repository<User>(connection);
        repository.Delete(id);
    }
}