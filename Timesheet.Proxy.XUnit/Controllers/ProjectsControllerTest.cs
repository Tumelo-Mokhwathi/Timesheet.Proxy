using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.XUnit.Infrastructure.Project;
using Microsoft.EntityFrameworkCore;
using Timesheet.Proxy.Models.Project;
using Timesheet.Proxy.Controllers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Timesheet.Proxy.XUnit.Infrastructure;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Timesheet.Proxy.XUnit.Controllers
{
    public class ProjectsControllerTest
    {
        private readonly Mock<IProjectService> _mock;

        private readonly ProjectsController _controller;

        public ProjectsControllerTest()
        {
            _mock = new Mock<IProjectService>();
            _controller = new ProjectsController(_mock.Object);
        }

        [Fact]
        public void GetProjectSuccesfully()
        {
            var result = _controller.GetProjects();

            Assert.NotNull(result);
        }

        [Fact]
        public void AddProjectSuccesfully()
        {
            var create = new Create
            {
                ProjectName = "Vodacom",
                ProjectCode = "Vodacom2020",
                Comment = "Vodacom created successfully"
            };

            var result = _controller.AddProject(create);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateProjectSuccesfully() 
        {
            var update = new Update
            {
                ProjectId = 1,
                ProjectName = "Vodacom",
                ProjectCode = "Vodacom2020",
                Comment = "Vodacom created successfully"
            };

            var result = _controller.UpdateProject(update);

            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteProjectSuccesfully()
        {
            var update = new Update
            {
                ProjectId = 1,
                ProjectName = "Vodacom",
                ProjectCode = "Vodacom2020",
                Comment = "Vodacom created successfully"
            };

            var result = _controller.UpdateProject(update);

            Assert.NotNull(result);
        }
    }
}
