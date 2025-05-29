using Tutorial11.Datas;
using Tutorial11.DTOs;
using Tutorial11.Exeptions;

namespace Tutorial11.Services;

public abstract class PatientService : IPatientService
{
    private AppDbContentext _context;

    public void PatientService(AppDbContentext context)
    {
        _context = context;
    }

    public async Task<PatientForReturnDTO> GetPatient(int id)
    {
        
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == id);
        
        if (patient == null)
        {
            throw new NotFoundException($"Nie znaleziono patienta o id: {id}");
        }
        
        var patientResult = new PatientForReturnDTO()
        {
            
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(pr => pr.DueDate)
                .Select(pr => new PrescriptionForReturnDTO
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new DoctorForReturnDTO
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName
                    },
                    Medicaments = pr.PrescriptionMedicaments
                        .Select(pm => new MedicamentForReturnDTO()
                        {
                            IdMedicament = pm.IdMedicament,
                            Name = pm.Medicament.Name,
                            Dose = pm.Dose,
                            Description = pm.Details
                        }).ToList()
                }).ToList()
        };
        return patientResult;

        
    }
}