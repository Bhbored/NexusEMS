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
        public Guid AuthorUserId { get; set; }//the one writing the message since it's like chat

        [Required, MaxLength(4000)]
        public string Body { get; set; } = string.Empty;

        //Navigation Property
        public ComplaintCase ComplaintCase { get; set; } = default!;
    }
}
