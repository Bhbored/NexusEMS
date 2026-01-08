using System;
using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.Models
{
    public class WorkScheduleAssignment : EntityBase
    {
        [Required]
        public Guid WorkScheduleId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public bool IsDayOff { get; set; } = false;

        [MaxLength(500)]
        public string? Notes { get; set; }

        //Navigation Property
        public WorkSchedule? WorkSchedule { get; set; }
        public Employee? Employee { get; set; }
    }
}
