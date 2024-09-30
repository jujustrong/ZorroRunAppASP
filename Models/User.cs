using System.ComponentModel.DataAnnotations;

namespace ZorroASP.Models;

public class User
{
    [Required]
    public int ID { get; set; }

    [Required]
    [StringLength(100)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    public List<Run> Runs { get; set; }
}