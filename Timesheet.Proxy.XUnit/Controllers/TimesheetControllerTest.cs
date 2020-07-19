using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.Controllers;
using Xunit;
using Timesheet.Proxy.Models.Timesheet;
using Microsoft.AspNetCore.Mvc;

namespace Timesheet.Proxy.XUnit.Controllers
{
    public class TimesheetControllerTest
    {
        private readonly Mock<ITimesheetService> _mock;

        private readonly TimesheetsController _controller;

        public TimesheetControllerTest()
        {
            _mock = new Mock<ITimesheetService>();
            _controller = new TimesheetsController(_mock.Object);
        }

        [Fact]
        public void GetProjectSuccesfully()
        {
            var result = _controller.GetTimesheets();

            Assert.NotNull(result);
        }

        [Fact]
        public void AddTimesheetSuccesfully() 
        {
            var create = new Create
            {
               SelectedProject = "Vodacom 2",
               SelectedActivity = "Vodacom Projects 2",
               FromTime = new TimeSpan(08, 30, 00),
               ToTime = new TimeSpan(16, 00, 00),
               TotalHours = 8,
               DateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000),
               Comment = "I was busy with vodacom project 2"
            };

            var result = _controller.AddTimesheets(create);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateTimesheetSuccesfully() 
        {
            var update = new Update
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

            var result = _controller.UpdateTimesheet(update);

            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteTimesheetSuccesfully() 
        {
            var update = new Update
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

            var result = _controller.UpdateTimesheet(update);

            Assert.NotNull(result);
        }
    }
}
