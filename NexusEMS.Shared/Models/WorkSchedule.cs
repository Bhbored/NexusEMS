using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NexusEMS.Shared.Enums;

namespace NexusEMS.Shared.Models
{
    public class WorkSchedule : EntityBase
    {
        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public DateOnly PeriodStart { get; set; }
        public DateOnly PeriodEnd { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public WorkScheduleStatus Status { get; set; } = WorkScheduleStatus.Draft;

        public Guid? ApprovedByUserId { get; set; }
        public DateTime? SubmittedAtUtc { get; set; }
        public DateTime? ApprovedAtUtc { get; set; }
        public DateTime? RejectedAtUtc { get; set; }

        [MaxLength(500)]
        public string? ApprovalNotes { get; set; }

        public string ScheduleDataJson { get; set; } = "{}";

    //Navigation Property
    public Department? Department { get; set; }
    public User? CreatedByUser { get; set; }
    public User? ApprovedByUser { get; set; }
    public ICollection<WorkScheduleAssignment> Assignments { get; set; } = new List<WorkScheduleAssignment>();
}
}
