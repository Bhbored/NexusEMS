using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalaryPackage : EntityBase
    {
        [Required]
        public Guid EmployeeProfileId { get; set; }

        public DateOnly EffectiveFrom { get; set; }
        public DateOnly? EffectiveTo { get; set; }

        public SalaryCalculationMode CalculationMode { get; set; } = SalaryCalculationMode.Mixed;

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

        //Navigation Property
        public Employee Employee { get; set; } = default!;
        public User? CreatedByUser { get; set; }
        public ICollection<SalaryComponent> Components { get; set; } = new List<SalaryComponent>();
    }
}
