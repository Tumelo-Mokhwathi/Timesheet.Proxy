using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Timesheet;

namespace Timesheet.Proxy.Services.Interfaces
{
    public interface ITimesheetService 
    {
        Timesheets[] GetAllTimesheets();
        Timesheets AddTimesheet(Create addTimesheet);
        Timesheets GetById(int id);
        object DeleteTimesheet(int id);
        Timesheets Update(Update updateTimesheet); 
    }
}
