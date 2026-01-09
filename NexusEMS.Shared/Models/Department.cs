using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.Models;

public class Department : EntityBase
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [MaxLength(30)]
    public string? Code { get; set; }

    [Required]
    public Guid BranchId { get; set; }
    public Guid? ChiefId { get; set; }
    public decimal? Budget { get; set; }
    public bool IsSystemDepartment { get; set; } = false;// HR/Accounting departments

    //Navigation Property
    public Branch? Branch { get; set; }
    public Employee? Chief { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
    public ICollection<WorkSchedule> WorkSchedules { get; set; } = [];
    public ICollection<ComplaintCase> ComplaintCases { get; set; } = [];
    public ICollection<AuditLog> AuditLogs { get; set; } = [];
    public ICollection<SalaryConfiguration> SalaryConfigurations { get; set; } = [];


    //readonly
    public string DepartmentChiefName
    {
        get
        {
            var chief = Chief ?? Employees?.FirstOrDefault(e => e.Id == ChiefId);
            if (chief == null) return string.Empty;
            var first = chief.FirstName ?? string.Empty;
            var last = chief.LastName ?? string.Empty;
            return $"{first} {last}".Trim();
        }
    }
}