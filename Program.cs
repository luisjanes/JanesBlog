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
        //ReadUser(connection);
        //CreateUser(connection);
        //UpdateUser(connection);
        //DeleteUser(connection);
    }
    public static void ReadUsers(MySqlConnection connection)
    {
        var userRepository = new UserRepository(connection);
        var users = userRepository.Get();
        foreach (var user in users)
            Console.WriteLine(user.Name);

    }
    public static void ReadUser(MySqlConnection connection)
    {
        var user = connection.Get<User>(2);
        Console.WriteLine(user.Name);
        Console.WriteLine(user.Email);
    }
    public static void CreateUser(MySqlConnection connection)
    {
        var user = new User() 
        { 
            Id = 0,
            Name = "Carolina",
            Email = "carolina@gmail.com",
            PasswordHash = "HASH",
            Bio = "A Grande Carolina",
            Image = "https://",
            Slug = "carolina"
        };
        connection.Insert<User>(user);
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
        connection.Update<User>(user);
    }
    public static void DeleteUser(MySqlConnection connection)
    {
        var user = connection.Get<User>(6);
        connection.Delete<User>(user);
    }
}