using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class Branch : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [MaxLength(30)]
        public string? Code { get; set; }

        public Guid? ManagerUserId { get; set; }
        public string? Location { get; set; }
        public decimal? Budget { get; set; }
        public string? ContactNumber { get; set; }

        //Navigation Property
        public User? Manager { get; set; }
        public ICollection<Department> Departments { get; set; } = [];
        public ICollection<Employee> Employees { get; set; } = [];
        public ICollection<User> Users { get; set; } = [];
        public ICollection<ComplaintCase> ComplaintCases { get; set; } = [];
        public ICollection<AuditLog> AuditLogs { get; set; } = [];
        public ICollection<SalaryConfiguration> SalaryConfigurations { get; set; } = [];
    }
}
