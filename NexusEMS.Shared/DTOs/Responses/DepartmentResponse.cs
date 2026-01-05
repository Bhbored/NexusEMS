namespace NexusEMS.Shared.DTOs.Responses;

public class DepartmentResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? HeadOfDepartmentId { get; set; }
    public string? HeadOfDepartmentName { get; set; }
    public decimal? Budget { get; set; }
    public int EmployeeCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}