using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class PayrollRun : EntityBase
    {
        public DateOnly PeriodStart { get; set; }
        public DateOnly PeriodEnd { get; set; }

        public PayrollRunStatus Status { get; set; } = PayrollRunStatus.Draft;

        [Required]
        public Guid CreatedByUserId { get; set; }

        public DateTime? FinalizedAtUtc { get; set; }

    //Navigation Property
    public User? CreatedByUser { get; set; }
    public ICollection<SalarySlipSnapshot> SalarySlips { get; set; } = new List<SalarySlipSnapshot>();
}
}
