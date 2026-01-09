using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class AttendanceEvent : EntityBase
    {
        [Required]
        public Guid EmployeeProfileId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public AttendanceEventType EventType { get; set; } = AttendanceEventType.CheckIn;
        public VerificationMethod VerificationMethod { get; set; } = VerificationMethod.Manual;

        [MaxLength(100)]
        public string? DeviceId { get; set; }

        [MaxLength(200)]
        public string? LocationLabel { get; set; }

        public string? MetaJson { get; set; }

        //Navigation Property
        public Employee Employee { get; set; } = default!;
    }
}
