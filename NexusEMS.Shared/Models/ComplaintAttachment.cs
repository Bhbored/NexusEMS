using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class ComplaintAttachment : EntityBase
    {
        [Required]
        public Guid ComplaintCaseId { get; set; }

        [Required, MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string ContentType { get; set; } = "application/octet-stream";

        public long SizeBytes { get; set; }

        [Required, MaxLength(500)]
        public string StoragePath { get; set; } = string.Empty;

        [Required]
        public Guid UploadedByUserId { get; set; }

        //Navigation Property
        public ComplaintCase ComplaintCase { get; set; } = default!;
    }
}
