using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
    }

    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public double AverageSalary => Employees.Select(employee => employee.Salary).Sum() / Employees.Count;

        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void PrintEmployees() 
            => Employees.OrderByDescending(employee => employee.Salary).ToList().ForEach(employee => Console.WriteLine($"{employee.Name} {employee.Salary:f2}"));
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split();
                Employee employee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2]);

                if (!departments.Exists(department => department.Name == employee.Department))
                    departments.Add(new Department(employee.Department));

                departments.Find(department => department.Name == employee.Department).Employees.Add(employee);
            }

            Department highestPaidDepartment = departments.OrderByDescending(department => department.AverageSalary).ToArray()[0];
            Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Name}");
            highestPaidDepartment.PrintEmployees();
        }
    }
}
