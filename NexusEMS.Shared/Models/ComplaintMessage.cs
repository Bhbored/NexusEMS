using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class ComplaintMessage : EntityBase
    {
        [Required]
        public Guid ComplaintCaseId { get; set; }

        [Required]
        public Guid AuthorUserId { get; set; }

        [Required, MaxLength(4000)]
        public string Body { get; set; } = string.Empty;

        public bool IsInternal { get; set; } = false;

        //Navigation Property
        public ComplaintCase ComplaintCase { get; set; } = default!;
    }
}
