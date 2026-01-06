using NexusEMS.Shared.Models;

namespace NexusEMS.Web.Tests;

public static class MockDepartments
{
    public static List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department
            {
                Id = 1,
                Name = "Engineering",
                Description = "Software Development & QA",
                HeadOfDepartmentId = 2,
                HeadOfDepartmentName = "Chief User",
                Budget = 500000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Department
            {
                Id = 2,
                Name = "Sales",
                Description = "Global Sales Team",
                HeadOfDepartmentId = null,
                HeadOfDepartmentName = null,
                Budget = 300000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Department
            {
                Id = 3,
                Name = "Human Resources",
                Description = "Recruiting & Employee Relations",
                HeadOfDepartmentId = null,
                HeadOfDepartmentName = null,
                Budget = 150000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Department
            {
                Id = 4,
                Name = "Marketing",
                Description = "Brand & Communications",
                HeadOfDepartmentId = null,
                HeadOfDepartmentName = null,
                Budget = 250000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }
}

