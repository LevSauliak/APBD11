using WebApplication1.DTOs;

public interface IPrescriptionService
{
    Task<int> AddPrescription(PrescriptionDTO prescriptionDto);
}