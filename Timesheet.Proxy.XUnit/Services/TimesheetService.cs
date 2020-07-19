using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.XUnit.Infrastructure;
using Xunit;

namespace Timesheet.Proxy.XUnit.Services
{
    public class TimesheetService : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public TimesheetService(DbFixture fixture) 
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        private async Task<Proxy.Services.TimesheetService> GetInMemoryProjectService()
        {
            var dbContext = _serviceProvider.GetRequiredService<TimesheetContext>();
            await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);
            await dbContext.Database.EnsureDeletedAsync().ConfigureAwait(false);
            return new Proxy.Services.TimesheetService(dbContext);
        }

        [Fact]
        public async Task ItAddTimesheetSuccessfully()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const string selectedProject = "Vodacom 2";
            const string selectedActivity = "Vodacom Projects 2";
            TimeSpan fromTime = new TimeSpan(08, 30, 00);
            TimeSpan toTime = new TimeSpan(16, 00, 00);
            const int totalHours = 8;
            DateTime dateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000);
            const string comment = "I was busy with vodacom project 2";

            var timesheet = service.AddTimesheet(new Proxy.Models.Timesheet.Create
            {
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            });

            Assert.Equal(selectedProject, timesheet.SelectedProject);
            Assert.Equal(selectedActivity, timesheet.SelectedActivity);
            Assert.Equal(fromTime, timesheet.FromTime);
            Assert.Equal(toTime, timesheet.ToTime);
            Assert.Equal(totalHours, timesheet.TotalHours);
            Assert.Equal(dateBooked, timesheet.DateBooked);
            Assert.Equal(comment, timesheet.Comment);
        }

        [Fact]
        public async Task ItGetAllTimesheetsSuccessfully()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int timesheetID = 1;
            const string selectedProject = "Vodacom 2";
            const string selectedActivity = "Vodacom Projects 2";
            TimeSpan fromTime = new TimeSpan(08, 30, 00);
            TimeSpan toTime = new TimeSpan(16, 00, 00);
            const int totalHours = 8;
            DateTime dateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000);
            const string comment = "I was busy with vodacom project 2";

            Timesheets timesheet = new Timesheets()
            {
                TimesheetID = timesheetID,
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            };

            var timesheetCreated = service.AddTimesheet(new Proxy.Models.Timesheet.Create
            {
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            });

            Assert.Single(service.GetAllTimesheets().ToArray());
        }

        [Fact]
        public async Task ItUpdateTimesheetSuccessfully() 
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int timesheetID = 2;
            const string selectedProject = "Vodacom 2";
            const string selectedActivity = "Vodacom Projects 2";
            TimeSpan fromTime = new TimeSpan(08, 30, 00);
            TimeSpan toTime = new TimeSpan(16, 00, 00);
            const int totalHours = 8;
            DateTime dateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000);
            const string comment = "I was busy with vodacom project 2";

            Timesheets timesheet = new Timesheets()
            {
                TimesheetID = timesheetID,
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            };

            var timesheetCreated = service.AddTimesheet(new Proxy.Models.Timesheet.Create
            {
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            });

            var result = service.GetAllTimesheets().First();

            Proxy.Models.Timesheet.Update model = new Proxy.Models.Timesheet.Update
            {
                TimesheetID = 2,
                SelectedProject = "Vodacom 2",
                SelectedActivity = "Vodacom Projects 2",
                FromTime = new TimeSpan(08, 30, 00),
                ToTime = new TimeSpan(16, 00, 00),
                TotalHours = 8,
                DateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000),
                Comment = "I was busy with vodacom project 2"
            };

            var timesheetUpdated = service.Update(model);

            Assert.Equal(timesheetUpdated.TimesheetID, model.TimesheetID);
            Assert.Equal(timesheetUpdated.SelectedProject, model.SelectedProject);
            Assert.Equal(timesheetUpdated.SelectedActivity, model.SelectedActivity);
            Assert.Equal(timesheetUpdated.FromTime, model.FromTime);
            Assert.Equal(timesheetUpdated.ToTime, model.ToTime);
            Assert.Equal(timesheetUpdated.TotalHours, model.TotalHours);
            Assert.Equal(timesheetUpdated.DateBooked, model.DateBooked);
            Assert.Equal(timesheetUpdated.Comment, model.Comment);
        }

        [Fact]
        public async Task DeleteTimesheet()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int timesheetID = 2;
            const string selectedProject = "Vodacom 2";
            const string selectedActivity = "Vodacom Projects 2";
            TimeSpan fromTime = new TimeSpan(08, 30, 00);
            TimeSpan toTime = new TimeSpan(16, 00, 00);
            const int totalHours = 8;
            DateTime dateBooked = new DateTime(2020, 06, 4, 00, 00, 00, 000);
            const string comment = "I was busy with vodacom project 2";

            Timesheets timesheet = new Timesheets()
            {
                TimesheetID = timesheetID,
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            };

            var timesheetCreated = service.AddTimesheet(new Proxy.Models.Timesheet.Create
            {
                SelectedProject = selectedProject,
                SelectedActivity = selectedActivity,
                FromTime = fromTime,
                ToTime = toTime,
                TotalHours = totalHours,
                DateBooked = dateBooked,
                Comment = comment
            });

            var result = service.GetAllTimesheets().First();

            var timesheetDeleted = service.DeleteTimesheet(result.TimesheetID);

            Assert.NotNull(timesheetDeleted);
        }
    }
}
