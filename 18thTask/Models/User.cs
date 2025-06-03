using _18thTask.Models;
using _18thTask.Interfaces;
namespace _18thTask.Models;
public class User:Entity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"User Name: {UserName} Email: {Email} Role: {Role}");
    }

    public User(string userName, string email, Role role)
    {
        UserName = userName;
        Email = email;
        Role = role;
    }
}