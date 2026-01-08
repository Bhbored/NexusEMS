using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class WeeklyRatingRevision : EntityBase
    {
        [Required]
        public Guid WeeklyRatingId { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

    //Navigation Property
    public WeeklyRating WeeklyRating { get; set; } = default!;
    public User? CreatedByUser { get; set; }
}
}
