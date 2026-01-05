using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.DTOs.Requests;

public class UpdateDepartmentRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public int? HeadOfDepartmentId { get; set; }
    public decimal? Budget { get; set; }
}