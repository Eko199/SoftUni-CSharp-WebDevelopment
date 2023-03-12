namespace SoftUni;

using System.Text;

using Microsoft.EntityFrameworkCore;

using Data;
using Models;

public class StartUp
{
    public static void Main(string[] args)
    {
        Console.WriteLine(RemoveTown(new SoftUniContext()));
    }

    //Problem 03.
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
            .AsNoTracking()
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            });

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine(
                $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 04.
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .AsNoTracking()
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            });

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine(
                $"{employee.FirstName} - {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 05.
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .AsNoTracking()
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            });

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine(
                $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 06.
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        context.Employees
            .First(e => e.LastName == "Nakov")
            .Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

        context.SaveChanges();

        List<string> addresses = context.Employees
            .AsNoTracking()
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToList();

        var sb = new StringBuilder();
        addresses.ForEach(a => sb.AppendLine(a));

        return sb.ToString().TrimEnd();
    }

    //Problem 07.
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .AsNoTracking()
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project!.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.Project!.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished",
                    })
                    .ToList()
            })
            .ToList();

        var sb = new StringBuilder();

        employees.ForEach(e =>
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
            e.Projects.ForEach(p => sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}"));
        });

        return sb.ToString().TrimEnd();
    }

    //Problem 08.
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .AsNoTracking()
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            })
            .OrderByDescending(a => a.EmployeeCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10);

        var sb = new StringBuilder();

        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 09.
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee147 = context.Employees
            .AsNoTracking()
            .Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .Select(ep => ep.Project!.Name)
                    .OrderBy(p => p)
                    .ToList()
            })
            .SingleOrDefault(e => e.EmployeeId == 147);

        var sb = new StringBuilder();

        sb.AppendLine($"{employee147?.FirstName} {employee147?.LastName} - {employee147?.JobTitle}");
        employee147?.Projects.ForEach(p => sb.AppendLine(p));

        return sb.ToString().TrimEnd();
    }

    //Problem 10.
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        Department[] departments = context.Departments
            .AsNoTracking()
            .Include(d => d.Manager)
            .Include(d => d.Employees)
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .ToArray();

        var sb = new StringBuilder();

        foreach (Department department in departments)
        {
            sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

            foreach (Employee employee in department.Employees
                         .OrderBy(e => e.FirstName)
                         .ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 11.
    public static string GetLatestProjects(SoftUniContext context)
    {
        var projects = context.Projects
            .AsNoTracking()
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToArray();

        var sb = new StringBuilder();

        foreach (var project in projects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 12.
    public static string IncreaseSalaries(SoftUniContext context)
    {
        List<Employee> employees = context.Employees
            .Where(e => 
                new HashSet<string> { "Engineering", "Tool Design", "Marketing", "Information Services"}
                    .Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        employees.ForEach(e => e.Salary *= 1.12M);
        context.SaveChanges();

        var sb = new StringBuilder();
        employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));

        return sb.ToString().TrimEnd();
    }

    //Problem 13.
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 14.
    public static string DeleteProjectById(SoftUniContext context)
    {
        context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(ep => ep.ProjectId == 2));
        context.Projects.Remove(context.Projects.Find(2)!);

        context.SaveChanges();

        List<string> projectNames = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToList();

        var sb = new StringBuilder();
        projectNames.ForEach(p => sb.AppendLine(p));

        return sb.ToString().TrimEnd();
    }

    //Problem 15.
    public static string RemoveTown(SoftUniContext context)
    {
        Town? seattle = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

        context.Employees
            .Where(e => e.Address.Town == seattle)
            .ToList()
            .ForEach(e => e.AddressId = null);

        Address[] addressesToDelete = context.Addresses
            .Where(a => a.Town == seattle)
            .ToArray();

        context.Addresses.RemoveRange(addressesToDelete);
        context.Towns.Remove(seattle);
        context.SaveChanges();

        return $"{addressesToDelete.Length} addresses in {seattle.Name} were deleted";
    }
}