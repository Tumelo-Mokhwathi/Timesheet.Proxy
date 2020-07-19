using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models.Timesheet
{
    public class Create
    {
        [Theory, AutoData]
        public void ItSetPropertySelectedProject(string selectedProject, Proxy.Models.Timesheet.Create model)
        {
            model.SelectedProject = selectedProject;
            Assert.Equal(selectedProject, model.SelectedProject);
        }

        [Theory, AutoData]
        public void ItSetPropertySelectedActivity(string selectedActivity, Proxy.Models.Timesheet.Create model)
        {
            model.SelectedActivity = selectedActivity;
            Assert.Equal(selectedActivity, model.SelectedActivity);
        }

        [Theory, AutoData]
        public void ItSetPropertyFromTime(TimeSpan fromTime, Proxy.Models.Timesheet.Create model)
        {
            model.FromTime = fromTime;
            Assert.Equal(fromTime, model.FromTime);
        }

        [Theory, AutoData]
        public void ItSetPropertyToTime(TimeSpan toTime, Proxy.Models.Timesheet.Create model)
        {
            model.ToTime = toTime;
            Assert.Equal(toTime, model.ToTime);
        }

        [Theory, AutoData]
        public void ItSetPropertyTotalHours(decimal totalHours, Proxy.Models.Timesheet.Create model)
        {
            model.TotalHours = totalHours;
            Assert.Equal(totalHours, model.TotalHours);
        }

        [Theory, AutoData]
        public void ItSetPropertyDateBooked(DateTime dateBooked, Proxy.Models.Timesheet.Create model)
        {
            model.DateBooked = dateBooked;
            Assert.Equal(dateBooked, model.DateBooked);
        }

        [Theory, AutoData]
        public void ItSetPropertyComment(string comment, Proxy.Models.Timesheet.Create model)
        {
            model.Comment = comment;
            Assert.Equal(comment, model.Comment);
        }
    }
}
