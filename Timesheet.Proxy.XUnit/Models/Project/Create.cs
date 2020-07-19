using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models.Project
{
    public class Create
    {
        [Theory, AutoData]
        public void ItSetPropertyprojectName(string projectName, Proxy.Models.Project.Create model)
        {
            model.ProjectName = projectName;
            Assert.Equal(projectName, model.ProjectName);
        }

        [Theory, AutoData]
        public void ItSetPropertyProjectCode(string projectCode, Proxy.Models.Project.Create model)
        {
            model.ProjectCode = projectCode;
            Assert.Equal(projectCode, model.ProjectCode);
        }

        [Theory, AutoData]
        public void ItSetPropertyComment(string comment, Proxy.Models.Project.Create model)
        {
            model.Comment = comment;
            Assert.Equal(comment, model.Comment);
        }
    }
}
