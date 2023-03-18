namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Patient
{
    public Patient()
    {
        Visitations = new HashSet<Visitation>();
        Diagnoses = new HashSet<Diagnose>();
        Prescriptions = new HashSet<PatientMedicament>();
    }

    [Key]
    public int PatientId { get; set; }

    [MaxLength(50)] 
    [Unicode] 
    public string FirstName { get; set; } = null!;


    [MaxLength(50)]
    [Unicode]
    public string LastName { get; set; } = null!;

    [MaxLength(250)]
    [Unicode]
    public string Address { get; set; } = null!;

    [MaxLength(80)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public bool HasInsurance { get; set; }

    public ICollection<Visitation> Visitations { get; set; }

    public ICollection<Diagnose> Diagnoses { get; set; }

    public ICollection<PatientMedicament> Prescriptions { get; set; }
}