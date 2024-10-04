using System.ComponentModel.DataAnnotations;

namespace ZorroASP.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
}