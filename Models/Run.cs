using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Serialization;

namespace ZorroASP.Models;

public class Run
{
    [Required(ErrorMessage = "Null")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter a run type.")]
    public string RunType { get; set; }
    
    [Required]
    [Range(0, 50000, ErrorMessage = "Elevation gain must between 0 and 50000 feet.")]
    public int ElevationGain { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Location { get; set; }
    
    [Required]
    [Range(0, 1000, ErrorMessage = "Distance must be between 0 and 1000 miles.")]
    public double Distance { get; set; }
    
    [Required]
    [Range(30, 220, ErrorMessage = "Please enter valid heart rate data between 30 and 220.")]
    public int HeartRate { get; set; }
    
    [Required(ErrorMessage = "Please enter a date for the run.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",  ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    
}