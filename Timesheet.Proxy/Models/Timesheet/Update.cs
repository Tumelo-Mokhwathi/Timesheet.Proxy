using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models.Timesheet
{
    public class Update
    {
        [Required]
        public int TimesheetID { get; set; }
        [Required]
        public string SelectedProject { get; set; }
        [Required]
        public string SelectedActivity { get; set; }
        [Required]
        public TimeSpan FromTime { get; set; }
        [Required]
        public TimeSpan ToTime { get; set; }
        [Required]
        public decimal TotalHours { get; set; }
        [Required]
        public DateTime DateBooked { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
