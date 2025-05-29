using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Tutorial11.Models;

public class Presctription
{
    [Key]
    public int IdPresctription { get; set; }
    public DateOnly Data { get; set; }
    public DateOnly DueDate { get; set; }
    
    [ForeignKey("Patient")]
    public int IdPatient { get; set; }
    public Patient Patient { get; set; }
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }
    public Doctor Doctor { get; set; }
}