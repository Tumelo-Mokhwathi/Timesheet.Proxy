using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class Timesheets
    {
        [Theory, AutoData]
        public void ItSetPropertyTimesheetID(int timesheetID, Proxy.Models.Timesheets model)
        {
            model.TimesheetID = timesheetID;
            Assert.Equal(timesheetID, model.TimesheetID);
        }

        [Theory, AutoData]
        public void ItSetPropertySelectedProject(string selectedProject, Proxy.Models.Timesheets model)
        {
            model.SelectedProject = selectedProject;
            Assert.Equal(selectedProject, model.SelectedProject);
        }

        [Theory, AutoData]
        public void ItSetPropertySelectedActivity(string selectedActivity, Proxy.Models.Timesheets model)
        {
            model.SelectedActivity = selectedActivity;
            Assert.Equal(selectedActivity, model.SelectedActivity);
        }

        [Theory, AutoData]
        public void ItSetPropertyFromTime(TimeSpan fromTime, Proxy.Models.Timesheets model)
        {
            model.FromTime = fromTime;
            Assert.Equal(fromTime, model.FromTime);
        }

        [Theory, AutoData]
        public void ItSetPropertyToTime(TimeSpan toTime, Proxy.Models.Timesheets model)
        {
            model.ToTime = toTime; 
            Assert.Equal(toTime, model.ToTime);
        }

        [Theory, AutoData]
        public void ItSetPropertyTotalHours(decimal totalHours, Proxy.Models.Timesheets model)
        {
            model.TotalHours = totalHours;
            Assert.Equal(totalHours, model.TotalHours);
        }

        [Theory, AutoData]
        public void ItSetPropertyDateBooked(DateTime dateBooked, Proxy.Models.Timesheets model)
        {
            model.DateBooked = dateBooked;
            Assert.Equal(dateBooked, model.DateBooked);
        }

        [Theory, AutoData]
        public void ItSetPropertyComment(string comment, Proxy.Models.Timesheets model)
        {
            model.Comment = comment;
            Assert.Equal(comment, model.Comment);
        }
    }
}
