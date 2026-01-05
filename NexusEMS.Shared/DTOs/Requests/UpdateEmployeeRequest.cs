using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.DTOs.Requests;

public class UpdateEmployeeRequest
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
    public DateTime? TerminationDate { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    public string Position { get; set; } = string.Empty;

    public string? JobTitle { get; set; }
    public decimal? Salary { get; set; }

    [StringLength(20)]
    public string? EmployeeCode { get; set; }

    public string? WorkLocation { get; set; }
    public string? EmploymentType { get; set; }
    public bool IsActive { get; set; } = true;
}