using System;
using System.Collections.Generic;
using System.Text;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Timesheet;
using Timesheet.Proxy.Services.Interfaces;

namespace Timesheet.Proxy.XUnit.Infrastructure.Timesheet
{
    public class MockTimesheetService : ITimesheetService
    {
        public Timesheets[] GetAllTimesheets()
        {
            Timesheets[] timesheet = new Timesheets[]
            {
                NewTimesheet(),
                NewTimesheet()
            };

            timesheet[1].TimesheetID = 1;
            return timesheet;
        }
        public Timesheets AddTimesheet(Create addTimesheet)
        {
            return new Timesheets
            {
                SelectedProject = addTimesheet.SelectedProject,
                SelectedActivity = addTimesheet.SelectedActivity,
                FromTime = addTimesheet.FromTime,
                ToTime = addTimesheet.ToTime,
                TotalHours = addTimesheet.TotalHours,
                DateBooked = addTimesheet.DateBooked,
                Comment = addTimesheet.Comment
            };
        }

        public Timesheets GetById(int id)
        {
            return NewTimesheet();
        }

        public object DeleteTimesheet(int id)
        {
            return NewTimesheet();
        }
        public Timesheets Update(Update updateTimesheet)
        {
            return new Timesheets
            {
                TimesheetID = updateTimesheet.TimesheetID,
                SelectedProject = updateTimesheet.SelectedProject,
                SelectedActivity = updateTimesheet.SelectedActivity,
                FromTime = updateTimesheet.FromTime,
                ToTime = updateTimesheet.ToTime,
                TotalHours = updateTimesheet.TotalHours,
                DateBooked = updateTimesheet.DateBooked,
                Comment = updateTimesheet.Comment
            };
        }

        private static Timesheets NewTimesheet()
        {
            return new Timesheets
            {
                TimesheetID = 1,
                SelectedProject = "Vodacom 2",
                SelectedActivity = "Vodacom Projects 2",
                FromTime = new TimeSpan(08, 30, 00),
                ToTime = new TimeSpan(16, 00, 00),
                TotalHours = 8,
                DateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000),
                Comment = "I was busy with vodacom project 2"
            };
        }
    }
}
