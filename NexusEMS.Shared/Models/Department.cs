using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.Models;

public class Department
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public int? HeadOfDepartmentId { get; set; }
    public string? HeadOfDepartmentName { get; set; }

    public decimal? Budget { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public List<Employee>? Employees { get; set; }
}