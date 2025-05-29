using Tutorial11.Datas;
using Tutorial11.DTOs;
using Tutorial11.Exeptions;
using Tutorial11.Models;

namespace Tutorial11.Services;

public interface PrescriptionService : IPrescriptionService
{
    private readonly AppDbContentext _context;

    public PrescriptionService(AppDbContentext context)
    {
        _context = context;
    }

    public async Task AddPrescription(PrescriptionForRequestDTO prescription)
    {
        if (prescription.Medicaments == null || prescription.Medicaments.Count == 0)
        {
            throw new BadReqException("Nie znaleziono medicament");
        }

        if (prescription.Medicaments.Count > 10)
        {
            throw new BadReqException("ilosc medicamentu max 10 twoja wynosi: " + prescription.Medicaments.Count);
        }

        if (prescription.DueDate < prescription.Date)
        {
            throw new BadReqException("DueDate musi byc pozniejsza niz Date");
        }

        var Patient = await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == prescription.Patient.IdPatient);
        
        if (Patient == null)
        {
            Patient = new Patient
            {
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                BirthDate = prescription.Patient.Birthdate
            };
            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();
        }
        else
        {
            if (Patient.FirstName != prescription.Patient.FirstName ||
                Patient.LastName != prescription.Patient.LastName ||
                Patient.Birthdate != prescription.Patient.Birthdate)
            {
                throw new BadReqException("Zle dane pacjenta");
            }
        }

        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == prescription.IdDoctor);
        if (doctor == null) throw new BadReqException($"nie znaleziono Doktora o id: " + prescription.IdDoctor);

        var newPrescription = new Presctription()
        {
            IdPatient = prescription.Patient.IdPatient,
            IdDoctor = prescription.IdDoctor,
            DueDate = prescription.DueDate,
            Data = prescription.Date
        };
        _context.Prescriptions.Add(newPrescription);
        await _context.SaveChangesAsync();

        var newPrescriptionMedicaments = new List<PresctriptionMedicament>();
        foreach (var medicamentDto in prescription.Medicaments)
        {
            var medicament =
                await _context.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == Medicament.IdMedicament);
            if (medicament == null)
            {
                throw new NotFoundException($"Nie znaleziono medikamentu o id: " + Medicament.IdMedicament);
            }

            newPrescriptionMedicaments.Add(new PresctriptionMedicament()
            {
                IdMedicament = Medicament.IdMedicament,
                IdPresctription = newPrescription.IdPresctription,
                Dose = PresctriptionMedicament.Dose,
                Details = Medicament.Description
            });
        }

        await _context.PrescriptionMedicaments.AddRangeAsync(newPrescriptionMedicaments);
        await _context.SaveChangesAsync();
    }
}