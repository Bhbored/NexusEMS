using System;
using System.Collections.Generic;
using System.Text;

namespace NexusEMS.Shared.Models
{
    public class Position : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? BaseSalary { get; set; }
        public decimal? SalaryRangeMin { get; set; }
        public decimal? SalaryRangeMax { get; set; }
    }
}
