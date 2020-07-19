using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Timesheet.Proxy.XUnit.Models
{
    public class Projects
    {
        [Theory, AutoData]
        public void ItSetPropertyProjects(int projectId, Proxy.Models.Projects model)
        {
            model.ProjectId = projectId;
            Assert.Equal(projectId, model.ProjectId);
        }

        [Theory, AutoData]
        public void ItSetPropertyprojectName(string projectName, Proxy.Models.Projects model)
        {
            model.ProjectName = projectName;
            Assert.Equal(projectName, model.ProjectName);
        }

        [Theory, AutoData]
        public void ItSetPropertyProjectCode(string projectCode, Proxy.Models.Projects model)
        {
            model.ProjectCode = projectCode;
            Assert.Equal(projectCode, model.ProjectCode); 
        }

        [Theory, AutoData]
        public void ItSetPropertyComment(string comment, Proxy.Models.Projects model)
        {
            model.Comment = comment;
            Assert.Equal(comment, model.Comment);
        }
    }
}
