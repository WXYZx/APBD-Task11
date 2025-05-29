using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial11.Models;

[Table("Presctription_Medicament")]
public class PresctriptionMedicament
{
    [ForeignKey(nameof(IdMedicament))]
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdPresctription))]
    public int IdPresctription { get; set; }
    
    public int Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
    
}