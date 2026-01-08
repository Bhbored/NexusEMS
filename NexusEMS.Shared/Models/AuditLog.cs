using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class AuditLog : EntityBase
    {
        [Required]
        public Guid ActorUserId { get; set; }

        public AuditAction Action { get; set; }

        [Required, MaxLength(120)]
        public string EntityType { get; set; } = string.Empty;

        [MaxLength(80)]
        public string? EntityId { get; set; }

        public Guid? DepartmentId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? EmployeeId { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? OldValuesJson { get; set; }
        public string? NewValuesJson { get; set; }

        [MaxLength(60)]
        public string? IpAddress { get; set; }

        [MaxLength(300)]
        public string? UserAgent { get; set; }

        //Navigation Property
        public User? ActorUser { get; set; }
        public Department? Department { get; set; }
        public Branch? Branch { get; set; }
        public Employee? Employee { get; set; }
    }
}
