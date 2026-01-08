using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class WeeklyRating : EntityBase
    {
        [Required]
        public Guid EmployeeProfileId { get; set; }

        public DateOnly WeekStartDate { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

        public bool IsFinalized { get; set; } = false;

    //Navigation Property
    public Employee Employee { get; set; } = default!;
    public User? CreatedByUser { get; set; }
    public ICollection<WeeklyRatingRevision> Revisions { get; set; } = new List<WeeklyRatingRevision>();
}
}
