using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;

using var context = new HospitalContext();

while (true)
{
    Console.WriteLine("What do you want to do?\n" +
                      "0) Save and Exit\n" +
                      "1) Show table\n" +
                      "2) Add to table");

    int actionChoice = int.Parse(Console.ReadLine());

    if (actionChoice == 0)
    {
        break;
    }

    Console.WriteLine("Choose a table:\n" +
                      "1) Doctors\n" +
                      "2) Visitations\n" +
                      "3) Patients\n" +
                      "4) Diagnoses\n" +
                      "5) PatientsMedicaments\n" +
                      "6) Medicaments");

    int tableChoice = int.Parse(Console.ReadLine());

    HandleChoices(context, tableChoice, actionChoice);
}

context.SaveChanges();

static void HandleChoices(HospitalContext context, int tableChoice, int actionChoice)
{
    if (actionChoice == 1)
    {
        switch (tableChoice)
        {
            case 1:
                ShowDoctors(context);
                break;
            case 2:
                ShowVisitations(context);
                break;
            case 3:
                ShowPatients(context);
                break;
            case 4:
                ShowDiagnoses(context);
                break;
            case 5:
                ShowPatientsMedicaments(context);
                break;
            case 6:
                ShowMedicaments(context);
                break;
            default:
                throw new InvalidOperationException("Invalid table choice!");
        }
    }
    else if (actionChoice == 2)
    {
        switch (tableChoice)
        {
            case 1:
                AddDoctor(context);
                break;
            case 2:
                AddVisitation(context);
                break;
            case 3:
                AddPatient(context);
                break;
            case 4:
                AddDiagnose(context);
                break;
            case 5:
                AddPatientMedicament(context);
                break;
            case 6:
                AddMedicament(context);
                break;
            default:
                throw new InvalidOperationException("Invalid table choice!");
        }

        context.SaveChanges();
    }
    else
    {
        throw new InvalidOperationException("Invalid action choice!");
    }
}

static void ShowDoctors(HospitalContext context)
    => context.Doctors
        .ToList()
        .ForEach(d => 
            Console.WriteLine($"Id:{d.DoctorId}; Name:{d.Name}; Specialty:{d.Specialty}"));

static void ShowPatients(HospitalContext context)
    => context.Patients
        .ToList()
        .ForEach(p => 
            Console.WriteLine($"Id:{p.PatientId}; Name:{p.FirstName} {p.LastName}; " +
                              $"Address:{p.Address}; Email:{p.Email}; HasInsurance:{p.HasInsurance}"));

static void ShowVisitations(HospitalContext context)
    => context.Visitations
        .Include(v => v.Doctor)
        .Include(v => v.Patient)
        .ToList()
        .ForEach(v => 
            Console.WriteLine($"Id:{v.VisitationId}; Date: {v.Date}; Comments:{v.Comments}; " +
                              $"Doctor:{v.Doctor.Name}; Patient:{v.Patient.FirstName} {v.Patient.LastName}"));

static void ShowDiagnoses(HospitalContext context)
    => context.Diagnoses
        .Include(d => d.Patient)
        .ToList()
        .ForEach(d =>
            Console.WriteLine($"Id:{d.DiagnoseId}; Name: {d.Name}; Comments:{d.Comments}; Patient:{d.Patient.FirstName} {d.Patient.LastName}"));

static void ShowPatientsMedicaments(HospitalContext context)
    => context.PatientsMedicaments
        .Include(pm => pm.Patient)
        .Include(pm => pm.Medicament)
        .ToList()
        .ForEach(pm =>
            Console.WriteLine($"Patient:{pm.Patient.FirstName} {pm.Patient.LastName}; Medicament:{pm.Medicament.Name}"));

static void ShowMedicaments(HospitalContext context)
    => context.Medicaments
        .ToList()
        .ForEach(m =>
            Console.WriteLine($"Id:{m.MedicamentId}; Name:{m.Name}"));

static T BuildEntity<T>()
{
    T entity = Activator.CreateInstance<T>();

    foreach (PropertyInfo property in typeof(T)
                 .GetProperties()
                 .Where(p => (!p.PropertyType.IsClass || p.PropertyType == typeof(string)) && !p.PropertyType.IsInterface
                             && p.GetCustomAttributesData()
                                 .All(a => a.AttributeType != typeof(KeyAttribute))))
    {
        Console.Write($"{property.Name}: ");
        string? value = Console.ReadLine();

        property.SetValue(entity, property.PropertyType.Name switch
        {
            nameof(String) => value,
            nameof(Int32) => int.Parse(value),
            nameof(Double) => double.Parse(value),
            nameof(Decimal) => decimal.Parse(value),
            nameof(Boolean) => bool.Parse(value),
            nameof(DateTime) => DateTime.Parse(value),
            _ => throw new InvalidOperationException("Property type not supported!")
        });
    }

    return entity;
}

static void AddDoctor(HospitalContext context)
    => context.Doctors.Add(BuildEntity<Doctor>());

static void AddPatient(HospitalContext context)
    => context.Patients.Add(BuildEntity<Patient>());

static void AddVisitation(HospitalContext context)
    => context.Visitations.Add(BuildEntity<Visitation>());

static void AddDiagnose(HospitalContext context)
    => context.Diagnoses.Add(BuildEntity<Diagnose>());

static void AddPatientMedicament(HospitalContext context)
    => context.PatientsMedicaments.Add(BuildEntity<PatientMedicament>());

static void AddMedicament(HospitalContext context)
    => context.Medicaments.Add(BuildEntity<Medicament>());