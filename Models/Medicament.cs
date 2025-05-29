using System.ComponentModel.DataAnnotations;

namespace Tutorial11.Models;

public class Medicament
{
    [Key]
    public static int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public static string Description { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
}