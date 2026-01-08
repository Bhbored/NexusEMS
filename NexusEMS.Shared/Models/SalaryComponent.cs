using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalaryComponent : EntityBase
    {
        [Required]
        public Guid SalaryPackageId { get; set; }

        public SalaryComponentType Type { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public bool IsDeduction { get; set; } = false;

        public SalaryComponentSource Source { get; set; } = SalaryComponentSource.Manual;

        [MaxLength(3)]
        public string Currency { get; set; } = "USD";

        //Navigation Property
        public SalaryPackage SalaryPackage { get; set; } = default!;
    }
}
