using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheet.Proxy.Models
{
    public class Timesheets
    {
        [Key]
        public int TimesheetID { get; set; } 
        public string SelectedProject { get; set; }
        public string SelectedActivity { get; set; }    
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public decimal TotalHours { get; set; }
        public DateTime DateBooked { get; set; } 
        public string Comment { get; set; }
    }  
}
