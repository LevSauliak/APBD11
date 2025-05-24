using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService: IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<bool> PatientExists(int patientId)
    {
        return await _context.Patients.FindAsync(patientId) != null;
    }

    public async Task<bool> AddPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        return true;
    }

    public async Task<bool> MedicationExists(int medicationId)
    {
        return await _context.Medicaments.FindAsync(medicationId) != null;
    }

    public async Task<int> AddPrescription(PrescriptionDTO prescriptionDto)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            Prescription prescription = new Prescription()
            {
                IdDoctor = prescriptionDto.Doctor.IdDoctor,
                IdPatient = prescriptionDto.Patient.IdPatient,
                Date = prescriptionDto.Date,
                DueDate = prescriptionDto.DueDate,
            };

            var result = await _context.Prescriptions.AddAsync(prescription);
            foreach (var medicament in prescriptionDto.Medicaments)
            {
                await _context.PrescriptionMedicaments.AddAsync(new PrescriptionMedicament()
                {
                    IdMedicament = medicament.IdMedicament,
                    IdPrescription = result.Entity.IdPrescription,
                    Dose = medicament.Dose,
                    Details = medicament.Description
                });
            }

            await _context.SaveChangesAsync();

            return result.Entity.IdPrescription;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }

    }
}