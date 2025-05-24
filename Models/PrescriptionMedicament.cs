using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }
    
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }

    public int? Dose { get; set; }

    public string Details { get; set; }
}