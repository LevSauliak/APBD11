using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class PrescriptionDTO
{
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }

    [MaxLength(10)]
    public List<MedicamentDto> Medicaments { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}