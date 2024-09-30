using System.ComponentModel.DataAnnotations;

namespace ZorroASP.Models;

public class Run
{
    [Required]
    public int ID { get; set; }

    [Required]
    
    public int TypeID { get; set; }

    [Required]
    public double Elevation { get; set; }

    [Required]
    [StringLength(100)]
    public string Location { get; set; }

    [Required]
    public double Mileage { get; set; }

    [Required]
    public int HeartRate { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int UserID { get; set; }
    
    public IEnumerable<RunType> RunTypes { get; set; }
}