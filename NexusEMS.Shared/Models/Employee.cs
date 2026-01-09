using NexusEMS.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.Models;

public class Employee : EntityBase
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }
    public Address? Address { get; set; }
    public Gender Gender { get; set; }

    [MaxLength(20)]
    public string? EmployeeCode { get; set; }

    public int NumberOfChildren { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool IsMarried { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
    public Guid? BranchId { get; set; }
    public DateTime HireDate { get; set; } = DateTime.Now;
    public DateTime? TerminationDate { get; set; }
    public Guid? PositionId { get; set; }
    public ContractType ContractType { get; set; }
    public EmploymentStatus EmploymentStatus { get; set; } = EmploymentStatus.Active;
    public Guid? ReportsToEmployeeId { get; set; }
    public string? WorkLocation { get; set; }
    public Guid? AssignedToUserId { get; set; }

    //Navigation Property
    public Department? Department { get; set; }
    public Branch? Branch { get; set; }
    public Position? Position { get; set; }
    public Employee? ReportsToEmployee { get; set; }
    public User? AssignedToUser { get; set; }
    public ICollection<AttendanceEvent> AttendanceEvents { get; set; } = new List<AttendanceEvent>();
    public ICollection<WeeklyRating> WeeklyRatingsReceived { get; set; } = new List<WeeklyRating>();
    public ICollection<ComplaintCase> ComplaintsCreated { get; set; } = new List<ComplaintCase>();
    public ICollection<SalaryPackage> SalaryPackages { get; set; } = new List<SalaryPackage>();
    public ICollection<SalaryChangeRequest> SalaryChangeRequests { get; set; } = new List<SalaryChangeRequest>();
    public ICollection<SalarySlipSnapshot> SalarySlips { get; set; } = new List<SalarySlipSnapshot>();
    public ICollection<Employee> DirectReports { get; set; } = new List<Employee>();
    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    //readonly 

    // Computed Properties (add after navigation properties, before the closing brace)
    public SalaryPackage? CurrentSalaryPackage
    {
        get
        {
            return SalaryPackages
                .Where(p => p.EffectiveFrom <= DateOnly.FromDateTime(DateTime.Now))
                .OrderByDescending(p => p.EffectiveFrom)
                .FirstOrDefault();
        }
    }

    public decimal CurrentGrossSalary
    {
        get
        {
            var package = CurrentSalaryPackage;
            if (package == null) return 0;

            return package.Components
                .Where(c => !c.IsDeduction)
                .Sum(c => c.Amount);
        }
    }

    public decimal CurrentNetSalary
    {
        get
        {
            var package = CurrentSalaryPackage;
            if (package == null) return 0;

            var gross = package.Components.Where(c => !c.IsDeduction).Sum(c => c.Amount);
            var deductions = package.Components.Where(c => c.IsDeduction).Sum(c => c.Amount);
            return gross - deductions;
        }
    }

    public decimal CurrentBaseSalary
    {
        get
        {
            var package = CurrentSalaryPackage;
            if (package == null) return 0;

            return package.Components
                .FirstOrDefault(c => c.Type == SalaryComponentType.Base)?.Amount ?? 0;
        }
    }
    public bool IsActive => EmploymentStatus == EmploymentStatus.Active;
}