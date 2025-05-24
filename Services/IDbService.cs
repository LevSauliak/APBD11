using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<bool> PatientExists(int patientId);
    Task<bool> AddPatient(Patient patient);
    Task<bool> MedicationExists(int medicationId);

    Task<int> AddPrescription(PrescriptionDTO prescriptionDto);
}