using Tutorial11.DTOs;

namespace Tutorial11.Services;

public interface IPrescriptionService
{
    Task AddPrescription(PatientForReturnDTO prescription);
}