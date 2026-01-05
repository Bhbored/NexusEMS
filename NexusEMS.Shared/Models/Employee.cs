
namespace NexusEMS.Shared.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public int DepartmentId { get; set; }
    public string Position { get; set; } = string.Empty;
    public string? JobTitle { get; set; }
    public decimal? Salary { get; set; }
    public string? EmployeeCode { get; set; }
    public int? ReportsTo { get; set; }
    public string? WorkLocation { get; set; }
    public string? EmploymentType { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public Department? Department { get; set; }
}