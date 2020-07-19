using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class GetTimesheetsWrapperResponse
    {
        [Theory, AutoData]
        public void ItSetPropertyCode(HttpStatusCode code, Proxy.Models.GetTimesheetsWrapperResponse model)
        {
            model.code = code;
            Assert.Equal(code, model.code);
        }

        [Theory, AutoData]
        public void ItSetPropertyprojectMessage(Proxy.Models.Timesheets[] timesheets, Proxy.Models.GetTimesheetsWrapperResponse model)
        {
            model.timesheets = timesheets;
            Assert.Equal(timesheets, model.timesheets);
        }

        [Theory, AutoData]
        public void ItSetPropertySource(string source, Proxy.Models.GetTimesheetsWrapperResponse model)
        {
            model.source = source;
            Assert.Equal(source, model.source);
        }
    }
}
