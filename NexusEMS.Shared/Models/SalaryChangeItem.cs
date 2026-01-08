using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalaryChangeItem : EntityBase
    {
        [Required]
        public Guid SalaryChangeRequestId { get; set; }

        public SalaryComponentType ComponentType { get; set; }

        public SalaryChangeItemAction Action { get; set; } = SalaryChangeItemAction.AddOrUpdate;

        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        public bool? IsDeduction { get; set; }

        public SalaryComponentSource Source { get; set; } = SalaryComponentSource.Manual;

        [MaxLength(3)]
        public string Currency { get; set; } = "USD";

        //Navigation Property
        public SalaryChangeRequest SalaryChangeRequest { get; set; } = default!;
    }
}
