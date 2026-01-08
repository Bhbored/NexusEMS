using System.ComponentModel.DataAnnotations;
using NexusEMS.Shared.Enums;

namespace NexusEMS.Shared.Models;

public class User : EntityBase
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Employee;
    public UserRole? SecondaryRole { get; set; }
    public bool IsOnline { get; set; } = false;
    public DateTime? LastLoginAt { get; set; }
    public DateTime? LastLogoutAt { get; set; }

    public Guid? EmployeeProfileId { get; set; }
    public Guid? BranchId { get; set; }
    public Guid? DepartmentId { get; set; }

    //Navigation Property
    public Employee? EmployeeProfile { get; set; }
    public Branch? Branch { get; set; }
    public Department? Department { get; set; }
    public ICollection<SessionLog> SessionLogs { get; set; } = new List<SessionLog>();
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    public ICollection<Branch> ManagedBranches { get; set; } = new List<Branch>();
    public ICollection<Department> ChiefOfDepartments { get; set; } = new List<Department>();
    public ICollection<ComplaintCase> ComplaintsAssigned { get; set; } = new List<ComplaintCase>();
    public ICollection<ComplaintCase> ComplaintsForwarded { get; set; } = new List<ComplaintCase>();
    public ICollection<WorkSchedule> WorkSchedulesCreated { get; set; } = new List<WorkSchedule>();
    public ICollection<WorkSchedule> WorkSchedulesApproved { get; set; } = new List<WorkSchedule>();
    public ICollection<SalaryChangeRequest> SalaryChangeRequestsCreated { get; set; } = new List<SalaryChangeRequest>();
    public ICollection<SalaryChangeRequest> SalaryChangeRequestsReviewed { get; set; } = new List<SalaryChangeRequest>();
    public ICollection<PayrollRun> PayrollRunsCreated { get; set; } = new List<PayrollRun>();
    public ICollection<WeeklyRating> WeeklyRatingsCreated { get; set; } = new List<WeeklyRating>();

    public bool HasRole(UserRole role)
    {
        return Role == role || SecondaryRole == role;
    }

    public bool HasAnyRole(params UserRole[] roles)
    {
        foreach (var role in roles)
        {
            if (Role == role || SecondaryRole == role)
                return true;
        }
        return false;
    }
}