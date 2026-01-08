using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalarySlipSnapshot : EntityBase
    {
        [Required]
        public Guid PayrollRunId { get; set; }

        [Required]
        public Guid EmployeeProfileId { get; set; }

        public decimal Gross { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPaid { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "USD";

        public string SnapshotJson { get; set; } = "{}";

        //Navigation Property
        public PayrollRun PayrollRun { get; set; } = default!;
        public Employee Employee { get; set; } = default!;
    }
}
