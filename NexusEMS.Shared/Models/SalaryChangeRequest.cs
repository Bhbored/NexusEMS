using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class SalaryChangeRequest : EntityBase
    {
        [Required]
        public Guid EmployeeProfileId { get; set; }

        public SalaryChangeStatus Status { get; set; } = SalaryChangeStatus.Draft;

        [Required]
        public Guid RequestedByUserId { get; set; }

        public Guid? ReviewedByUserId { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        public DateOnly EffectiveFrom { get; set; }

        public DateTime? ReviewedAtUtc { get; set; }
        public DateTime? AppliedAtUtc { get; set; }

    //Navigation Property
    public Employee Employee { get; set; } = default!;
    public User? RequestedByUser { get; set; }
    public User? ReviewedByUser { get; set; }
    public ICollection<SalaryChangeItem> Items { get; set; } = new List<SalaryChangeItem>();
}
}
