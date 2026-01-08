using System;
using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Shared.Models
{
    public class SessionLog : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime LoginAt { get; set; } = DateTime.UtcNow;

        public DateTime? LogoutAt { get; set; }

        [MaxLength(60)]
        public string? IpAddress { get; set; }

        [MaxLength(300)]
        public string? UserAgent { get; set; }

        [MaxLength(100)]
        public string? DeviceInfo { get; set; }

        public bool IsActive { get; set; } = true;

        public TimeSpan? SessionDuration
        {
            get
            {
                if (LogoutAt.HasValue)
                    return LogoutAt.Value - LoginAt;
                return null;
            }
        }

        //Navigation Property
        public User? User { get; set; }
    }
}
