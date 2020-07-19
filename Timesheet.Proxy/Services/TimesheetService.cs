using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Timesheet;
using Timesheet.Proxy.Services.Interfaces;

namespace Timesheet.Proxy.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly TimesheetContext _context;

        public TimesheetService(TimesheetContext context)
        {
            _context = context; 
        }

        public Timesheets[] GetAllTimesheets()
        {
            var allTimesheet = (from timesheet in _context.Timesheets select timesheet).ToArray();
            return allTimesheet;
        }
        public Timesheets AddTimesheet(Create addTimesheet)
        {
            var timesheet = new Timesheets
            {
                SelectedProject = addTimesheet.SelectedProject,
                SelectedActivity = addTimesheet.SelectedActivity,
                FromTime = addTimesheet.FromTime,
                ToTime = addTimesheet.ToTime,
                TotalHours = addTimesheet.TotalHours,
                DateBooked = addTimesheet.DateBooked,
                Comment = addTimesheet.Comment
            };

            _context.Add(timesheet);
            _context.SaveChanges();

            return timesheet;
        }

        public Timesheets GetById(int id)
        {
            var timesheet = _context.Timesheets.Find(id);

            if(timesheet == null)
            {
                throw new KeyNotFoundException("Timesheet not found for specified ID");
            }

            return timesheet;
        }

        public Timesheets Update(Update updateTimesheet)
        {
            var timesheet = GetById(updateTimesheet.TimesheetID);

            if (timesheet.SelectedProject != updateTimesheet.SelectedProject
                && _context.Timesheets.Any(c => c.SelectedProject.Equals(updateTimesheet.SelectedProject, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException("Timesheet already exists");
            }

            timesheet.SelectedProject = updateTimesheet.SelectedProject;
            timesheet.SelectedActivity = updateTimesheet.SelectedActivity;
            timesheet.FromTime = updateTimesheet.FromTime;
            timesheet.ToTime = updateTimesheet.ToTime;
            timesheet.TotalHours = updateTimesheet.TotalHours;
            timesheet.DateBooked = updateTimesheet.DateBooked;
            timesheet.Comment = updateTimesheet.Comment;

            _context.Update(timesheet);
            _context.SaveChanges();

            return timesheet;
        }

        public object DeleteTimesheet(int id)
        {
            var timesheet = _context.Timesheets.Find(id);

            _context.Timesheets.Remove(timesheet);
            return _context.SaveChanges();
        }
    }
}
