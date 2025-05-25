using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IPatientService
{
    Task<PatientDTO> GetPatient(int id);
}