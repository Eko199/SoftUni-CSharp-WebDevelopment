namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Medicament
{
    public Medicament()
    {
        Prescriptions = new HashSet<PatientMedicament>();
    }

    [Key]
    public int MedicamentId { get; set; }

    [MaxLength(50)] 
    [Unicode] 
    public string Name { get; set; } = null!;

    public ICollection<PatientMedicament> Prescriptions { get; set; }
}