namespace Tutorial11.DTOs;

public class PatientForReturnDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public ICollection<PrescriptionForReturnDTO> Prescriptions { get; set; }
}

public class MedicamentForReturnDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorForReturnDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}

public class PrescriptionForReturnDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<MedicamentForReturnDTO> Medicaments { get; set; }
    public DoctorForReturnDTO Doctor { get; set; }
}