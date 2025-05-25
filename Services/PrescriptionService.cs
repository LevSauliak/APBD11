using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services;

public class PrescriptionService : IPrescriptionService
{
    private IDbService _dbService;

    public PrescriptionService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<int> AddPrescription(PrescriptionDTO prescriptionDto)
    {
        if (prescriptionDto.DueDate < prescriptionDto.Date)
            throw new BadRequestException("Due date is before issue Date");
        
        foreach (var medication in prescriptionDto.Medicaments)
        {
            if (!await _dbService.MedicationExists(medication.IdMedicament))
                throw new NotFoundException("No such medication");
        }
        
        if (!await _dbService.PatientExists(prescriptionDto.Patient.IdPatient))
        {
            await _dbService.AddPatient(prescriptionDto.Patient);
        }
        
        return await _dbService.AddPrescription(prescriptionDto);
    }
}