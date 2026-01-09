using NexusEMS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class AuditLog : EntityBase
    //logs actions performed by users on various entities
    {
        [Required]
        public Guid ActorUserId { get; set; }//who performed the action
        public string ActorName { get; set; } = string.Empty;

        public AuditAction Action { get; set; }

        [Required, MaxLength(120)]
        public string EntityType { get; set; } = string.Empty;//the type of entity affected(employee info , salary , schedule etc)

        public Guid? EntityId { get; set; }//the specific entity affected


        //for filtering purposes
        public Guid? DepartmentId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? EmployeeId { get; set; }

        //don't forget the updated at when editing

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? OldValuesJson { get; set; }
        public string? NewValuesJson { get; set; }

        [MaxLength(60)]
        public string? IpAddress { get; set; }


        //Navigation Property
        public User? ActorUser { get; set; }
        public Department? Department { get; set; }
        public Branch? Branch { get; set; }
        public Employee? Employee { get; set; }
    }
}
