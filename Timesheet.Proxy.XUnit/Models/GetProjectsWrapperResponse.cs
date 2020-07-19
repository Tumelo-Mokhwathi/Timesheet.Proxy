using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class GetProjectsWrapperResponse
    {
        [Theory, AutoData]
        public void ItSetPropertyCode(HttpStatusCode code, Proxy.Models.GetProjectsWrapperResponse model)
        {
            model.code = code;
            Assert.Equal(code, model.code);
        }

        [Theory, AutoData]
        public void ItSetPropertyprojectMessage(Proxy.Models.Projects [] projects, Proxy.Models.GetProjectsWrapperResponse model)
        {
            model.projects = projects;
            Assert.Equal(projects, model.projects);
        }

        [Theory, AutoData]
        public void ItSetPropertySource(string source, Proxy.Models.GetProjectsWrapperResponse model)
        {
            model.source = source;
            Assert.Equal(source, model.source);
        }
    }
}
