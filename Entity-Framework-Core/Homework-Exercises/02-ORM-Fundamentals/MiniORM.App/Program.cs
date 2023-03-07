namespace MiniORM.App;

using Data;
using Data.Entities;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new SoftUniDbContext(
                @"Server=(LocalDb)\MSSQLLocalDB;Database=MiniORM;Integrated Security=True;Encrypt=False");

        context.Employees.Add(new Employee
        {
            FirstName = "Gosho",
            LastName = "Inserted",
            DepartmentId = context.Departments.First().Id,
            IsEmployed = true
        });

        context.Employees.Last().FirstName = "Modified";

        context.SaveChanges();
    }
}