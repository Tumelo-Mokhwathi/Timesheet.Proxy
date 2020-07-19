using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Timesheet;
using Xunit;

namespace Timesheet.Proxy.XUnit.Controllers
{
    public class TimesheetsIntegrationTest
    {
        private readonly string createSource = $"{Constants.Source.TimesheetPrefixName}";
        private readonly HttpStatusCode code = HttpStatusCode.OK;
        private readonly HttpStatusCode createdCode = HttpStatusCode.Created;
        private readonly HttpStatusCode updatedCode = HttpStatusCode.OK;


        [Theory, AutoData]
        public void GetTimesheets(Infrastructure.Timesheet.MockTimesheetService service)
        {
            var controller = new Proxy.Controllers.TimesheetsController(service);
            var result = controller.GetTimesheets();

            Assert.IsType<ActionResult<GetTimesheetsWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as GetTimesheetsWrapperResponse)?.source);
            Assert.Equal(code, (result.Value as GetTimesheetsWrapperResponse)?.code);
            AssertUnhandledExceptionsGetTimesheet(createSource, result);
        }

        [Theory, AutoData]
        public void AddTimesheet(Create model, Infrastructure.Timesheet.MockTimesheetService service)
        {
            var controller = new Proxy.Controllers.TimesheetsController(service);
            var result = controller.AddTimesheets(model);

            Assert.IsType<ActionResult<AddTimesheetWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as AddTimesheetWrapperResponse)?.source);
            Assert.Equal(createdCode, (result.Value as AddTimesheetWrapperResponse)?.code);
            Assert.Equal("Timesheet Created Succesfully", (result.Value as AddTimesheetWrapperResponse)?.message);
            AssertUnhandledExceptionsAddTimesheet(createSource, result);
        }

        [Theory, AutoData]
        public void DeleteTimesheet(int id, Infrastructure.Timesheet.MockTimesheetService service)
        {
            var controller = new Proxy.Controllers.TimesheetsController(service);
            var result = controller.DeleteTimesheet(id);

            Assert.IsType<ActionResult<DeleteWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as DeleteWrapperResponse)?.source);
            Assert.Equal(updatedCode, (result.Value as DeleteWrapperResponse)?.code);
            Assert.Equal("Timesheet Deleted Succesfully", (result.Value as DeleteWrapperResponse)?.message);
            AssertUnhandledExceptionsDeleteTimesheet(createSource, result);
        }

        [Theory, AutoData]
        public void UpdateTimesheet(Update model, Infrastructure.Timesheet.MockTimesheetService service)
        {
            var controller = new Proxy.Controllers.TimesheetsController(service); 
            var result = controller.UpdateTimesheet(model);

            Assert.IsType<ActionResult<UpdateWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as UpdateWrapperResponse)?.source);
            Assert.Equal(updatedCode, (result.Value as UpdateWrapperResponse)?.code);
            Assert.Equal("Timesheet Updated Succesfully", (result.Value as UpdateWrapperResponse)?.message);
            AssertUnhandledExceptionsUpdateTimesheet(createSource, result);
        }


        private static void AssertUnhandledExceptionsGetTimesheet(string source, ActionResult<GetTimesheetsWrapperResponse> result)
        {
            Assert.IsType<ActionResult<GetTimesheetsWrapperResponse>>(result);
            Assert.Equal(source, (result.Value as GetTimesheetsWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsAddTimesheet(string source, ActionResult<AddTimesheetWrapperResponse> result)
        {
            Assert.IsType<ActionResult<AddTimesheetWrapperResponse>>(result);
            Assert.IsType<AddTimesheetWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as AddTimesheetWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsDeleteTimesheet(string source, ActionResult<DeleteWrapperResponse> result)
        {
            Assert.IsType<ActionResult<DeleteWrapperResponse>>(result);
            Assert.IsType<DeleteWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as DeleteWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsUpdateTimesheet(string source, ActionResult<UpdateWrapperResponse> result)
        {
            Assert.IsType<ActionResult<UpdateWrapperResponse>>(result);
            Assert.IsType<UpdateWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as UpdateWrapperResponse)?.source);
        }
    }
}
