using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class ComplaintCase : EntityBase
    {
        [Required]
        public Guid CreatedByEmployeeProfileId { get; set; }// the user who created the complaint

        [Required]
        public Guid DepartmentId { get; set; }

        public Guid? BranchId { get; set; }

        [Required, MaxLength(140)]
        public string Subject { get; set; } = string.Empty;

        [Required, MaxLength(4000)]
        public string Description { get; set; } = string.Empty;

        public ComplaintTarget Target { get; set; } = ComplaintTarget.HR;
        public ComplaintCategory Category { get; set; } = ComplaintCategory.Other;
        public ComplaintSeverity Severity { get; set; } = ComplaintSeverity.Medium;
        public ComplaintStatus Status { get; set; } = ComplaintStatus.Submitted;

        public bool IsAnonymousToChief { get; set; } = false;
        public Guid? AssignedToUserId { get; set; }
        public bool IsForwardedToBranchManager { get; set; } = false;
        public Guid? ForwardedByUserId { get; set; }
        public DateTime? ForwardedAtUtc { get; set; }

        [MaxLength(500)]
        public string? ForwardingNotes { get; set; }

        public DateTime? ClosedAtUtc { get; set; }

    //Navigation Property
    public Employee CreatedByEmployeeProfile { get; set; } = default!;
    public Department Department { get; set; } = default!;
    public Branch? Branch { get; set; }
    public User? AssignedToUser { get; set; }
    public User? ForwardedByUser { get; set; }
    public ICollection<ComplaintMessage> Messages { get; set; } = new List<ComplaintMessage>();
    public ICollection<ComplaintAttachment> Attachments { get; set; } = new List<ComplaintAttachment>();
}
}
