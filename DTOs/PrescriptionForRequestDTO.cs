namespace Tutorial11.DTOs;

public class PrescriptionForRequestDTO
{
    public PatientForReturnDTO Patient { get; set; }
    public ICollection<DoctorForReturnDTO> Medicaments { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public int IdDoctor { get; set; }
}

public class PatientForRequestDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class MedicamentForRequestDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}