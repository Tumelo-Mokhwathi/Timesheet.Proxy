using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class AddTimesheetWrapperResponse
    {
        [Theory, AutoData]
        public void ItSetPropertyCode(HttpStatusCode code, Proxy.Models.AddTimesheetWrapperResponse model)
        {
            model.code = code;
            Assert.Equal(code, model.code);
        }

        [Theory, AutoData]
        public void ItSetPropertyprojectMessage(string message, Proxy.Models.AddTimesheetWrapperResponse model)
        {
            model.message = message;
            Assert.Equal(message, model.message);
        }

        [Theory, AutoData]
        public void ItSetPropertyTimesheet(object timesheet, Proxy.Models.AddTimesheetWrapperResponse model)
        {
            model.timesheet = timesheet;
            Assert.Equal(timesheet, model.timesheet);
        }

        [Theory, AutoData]
        public void ItSetPropertySource(string source, Proxy.Models.AddTimesheetWrapperResponse model)
        {
            model.source = source;
            Assert.Equal(source, model.source);
        }
    }
}
