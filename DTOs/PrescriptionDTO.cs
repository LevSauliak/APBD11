using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class PrescriptionDTO
{
    public PrescriptionPatientDTO Patient { get; set; }
    public PrescriptionDoctorDTO Doctor { get; set; }

    [MaxLength(10)]
    public List<MedicamentDto> Medicaments { get; set; }

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class PrescriptionPatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class PrescriptionDoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}