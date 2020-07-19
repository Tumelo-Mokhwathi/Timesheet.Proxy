using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class UpdateWrapperResponse
    {
        [Theory, AutoData]
        public void ItSetPropertyCode(HttpStatusCode code, Proxy.Models.UpdateWrapperResponse model)
        {
            model.code = code;
            Assert.Equal(code, model.code);
        }

        [Theory, AutoData]
        public void ItSetPropertyprojectMessage(string message, Proxy.Models.UpdateWrapperResponse model)
        {
            model.message = message;
            Assert.Equal(message, model.message);
        }

        [Theory, AutoData]
        public void ItSetPropertyTime(object item, Proxy.Models.UpdateWrapperResponse model)
        {
            model.item = item;
            Assert.Equal(item, model.item);
        }

        [Theory, AutoData]
        public void ItSetPropertySource(string source, Proxy.Models.UpdateWrapperResponse model)
        {
            model.source = source;
            Assert.Equal(source, model.source);
        }
    }
}
