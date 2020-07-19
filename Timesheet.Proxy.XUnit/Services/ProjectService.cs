using System;
using Timesheet.Proxy.XUnit.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Timesheet.Proxy.Models;
using System.Linq;
using Xunit;
using System.Net;

namespace Timesheet.Proxy.XUnit.Services
{
    public class ProjectService : IClassFixture<DbFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public ProjectService(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        private async Task<Proxy.Services.ProjectService> GetInMemoryProjectService()
        {
            var dbContext = _serviceProvider.GetRequiredService<TimesheetContext>();
            await dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);
            await dbContext.Database.EnsureDeletedAsync().ConfigureAwait(false);
            return new Proxy.Services.ProjectService(dbContext);
        }

        [Fact]
        public async Task ItAddProjectSuccessfully()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const string projectName = "Project";
            const string projectCode = "TD2020";
            const string comment = "comment";

            var project = service.AddProject(new Timesheet.Proxy.Models.Project.Create
            {
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            });

            Assert.Equal(projectName, project.ProjectName);
            Assert.Equal(projectCode, project.ProjectCode);
            Assert.Equal(comment, project.Comment);
        }

        [Fact]
        public async Task ItGetAllProjectsSuccessfully()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int projectId = 2;
            const string projectName = "ProjectName";
            const string projectCode = "TD2021";
            const string comment = "blah blah";

            Projects project = new Projects()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            };

            var projectCreated = service.AddProject(new Proxy.Models.Project.Create
            {
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            });

            Assert.Single(service.GetAllProjects().ToArray());
        }

        [Fact]
        public async Task UpdateProjectSuccessfully()  
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int projectId = 2;
            const string projectName = "MTN Project";
            const string projectCode = "MTN2020";
            const string comment = "MTN Project created in 2020";

            Projects project = new Projects()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            };

            var projectCreated = service.AddProject(new Proxy.Models.Project.Create
            {
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            });

            var result = service.GetAllProjects().First();

            Proxy.Models.Project.Update model = new Proxy.Models.Project.Update
            {
                ProjectId = 2,
                ProjectName = "ProjectName",
                ProjectCode = "TD2021",
                Comment = "blah blah"
            };

            var projectUpdated = service.Update(model);

            Assert.Equal(projectUpdated.ProjectId, model.ProjectId);
            Assert.Equal(projectUpdated.ProjectName, model.ProjectName);
            Assert.Equal(projectUpdated.ProjectCode, model.ProjectCode);
            Assert.Equal(projectUpdated.Comment, model.Comment);
        }

        [Fact]
        public async Task DeleteProject()
        {
            var service = await GetInMemoryProjectService().ConfigureAwait(false);

            const int projectId = 2;
            const string projectName = "MTN Project";
            const string projectCode = "MTN2020";
            const string comment = "MTN Project created in 2020";

            Projects project = new Projects()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            };

            var projectCreated = service.AddProject(new Proxy.Models.Project.Create
            {
                ProjectName = projectName,
                ProjectCode = projectCode,
                Comment = comment
            });

            var result = service.GetAllProjects().First();

            var projectDeleted = service.DeleteProject(result.ProjectId);

            Assert.NotNull(projectDeleted);
        }

    }
}
