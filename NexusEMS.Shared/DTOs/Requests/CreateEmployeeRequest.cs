using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.DTOs.Requests;

public class CreateEmployeeRequest
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    public string Position { get; set; } = string.Empty;

    public decimal? Salary { get; set; }

    [StringLength(20)]
    public string? EmployeeCode { get; set; }

    public string? EmploymentType { get; set; }
}