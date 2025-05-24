using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Patient
{
    
    [Key] 
    public int IdPatient { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime Birthdate { get; set; }
    
}