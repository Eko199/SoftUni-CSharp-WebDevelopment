namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Doctor
{
    public Doctor()
    {
        Visitations = new HashSet<Visitation>();
    }

    [Key]
    public int DoctorId { get; set; }

    [MaxLength(100)]
    [Unicode]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    [Unicode]
    public string Specialty { get; set; } = null!;

    public ICollection<Visitation> Visitations { get; set; }
}