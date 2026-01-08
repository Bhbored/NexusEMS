using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalaryConfiguration : EntityBase
    {
        [Required]
        public Guid? BranchId { get; set; }

        public Guid? DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public decimal BaseSalary { get; set; }
        public decimal HraPercentage { get; set; }
        public decimal DaPercentage { get; set; }
        public decimal ConveyanceAllowance { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal MarriedMultiplier { get; set; } = 1.1m;
        public decimal ChildMultiplier { get; set; } = 0.05m;
        public decimal PostGraduateMultiplier { get; set; } = 1.15m;
        public decimal PhdMultiplier { get; set; } = 1.25m;
        public decimal TwoYearIncrementPercentage { get; set; } = 5m;

        public bool IsActive { get; set; } = true;

        //Navigation Property
        public Branch? Branch { get; set; }
        public Department? Department { get; set; }
    }
}
