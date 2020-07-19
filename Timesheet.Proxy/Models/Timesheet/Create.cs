using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models.Timesheet
{
    public class Create
    {
        public string SelectedProject { get; set; }
        public string SelectedActivity { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public decimal TotalHours { get; set; }
        public DateTime DateBooked { get; set; }
        public string Comment { get; set; }
    }
}
