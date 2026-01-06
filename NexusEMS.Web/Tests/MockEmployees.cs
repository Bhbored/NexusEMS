using NexusEMS.Shared.Models;

namespace NexusEMS.Web.Tests;

public static class MockEmployees
{
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice@nexus.com",
                Phone = "+1 (555) 123-4567",
                DateOfBirth = new DateTime(1990, 5, 15),
                HireDate = new DateTime(2020, 1, 10),
                DepartmentId = 1,
                Position = "Senior Developer",
                JobTitle = "Senior Software Engineer",
                Salary = 120000,
                EmployeeCode = "EMP001",
                EmploymentType = "FullTime",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Employee
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob@nexus.com",
                Phone = "+1 (555) 234-5678",
                DateOfBirth = new DateTime(1988, 8, 20),
                HireDate = new DateTime(2019, 3, 15),
                DepartmentId = 2,
                Position = "Sales Lead",
                JobTitle = "Sales Manager",
                Salary = 100000,
                EmployeeCode = "EMP002",
                EmploymentType = "FullTime",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Employee
            {
                Id = 3,
                FirstName = "Charlie",
                LastName = "Brown",
                Email = "charlie@nexus.com",
                Phone = "+1 (555) 345-6789",
                DateOfBirth = new DateTime(1992, 12, 5),
                HireDate = new DateTime(2021, 6, 1),
                DepartmentId = 1,
                Position = "Product Owner",
                JobTitle = "Product Manager",
                Salary = 110000,
                EmployeeCode = "EMP003",
                EmploymentType = "FullTime",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Employee
            {
                Id = 4,
                FirstName = "Diana",
                LastName = "Prince",
                Email = "diana@nexus.com",
                Phone = "+1 (555) 456-7890",
                DateOfBirth = new DateTime(1985, 3, 25),
                HireDate = new DateTime(2018, 9, 10),
                DepartmentId = 3,
                Position = "HR Manager",
                JobTitle = "Human Resources Manager",
                Salary = 95000,
                EmployeeCode = "EMP004",
                EmploymentType = "FullTime",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }
}

