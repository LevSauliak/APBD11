using WebApplication1.Models;

namespace WebApplication1.DTOs;

public partial class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public List<PatientPrescriptionDTO> Prescriptions { get; set; }
}

public class PatientPrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public List<MedicamentDto> Medicaments { get; set; }
    public Doctor Doctor { get; set; }
}