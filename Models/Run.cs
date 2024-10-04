using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Serialization;

namespace ZorroASP.Models;

public class Run
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string RunType { get; set; }
    
    [Required]
    [Range(0, 1000, ErrorMessage = "Please enter a valid distance.")]
    public int ElevationGain { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Location { get; set; }
    
    [Required]
    [Range(0, 50000, ErrorMessage = "Please enter valid elevation data.")]
    public double Distance { get; set; }
    
    [Required]
    [Range(30, 220, ErrorMessage = "Please enter valid heart rate data.")]
    public int HeartRate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
}