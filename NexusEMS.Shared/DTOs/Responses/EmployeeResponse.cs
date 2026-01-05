using NexusEMS.Shared.Models;

namespace NexusEMS.Shared.DTOs.Responses;

public class EmployeeResponse
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
    public string? DepartmentName { get; set; }
    public string Position { get; set; } = string.Empty;
    public string? JobTitle { get; set; }
    public decimal? Salary { get; set; }
    public string? EmployeeCode { get; set; }
    public int? ReportsTo { get; set; }
    public string? WorkLocation { get; set; }
    public string? EmploymentType { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation property
    public Department? Department { get; set; }
}