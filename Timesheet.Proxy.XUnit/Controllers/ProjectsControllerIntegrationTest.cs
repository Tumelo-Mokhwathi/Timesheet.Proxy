using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Project;
using Xunit;

namespace Timesheet.Proxy.XUnit.Controllers
{
    public class ProjectsControllerIntegrationTest
    {
        private readonly string createSource = $"{Constants.Source.ProjectsPrefixName}";
        private readonly HttpStatusCode code = HttpStatusCode.OK;
        private readonly HttpStatusCode createdCode = HttpStatusCode.Created;
        private readonly HttpStatusCode updatedCode = HttpStatusCode.OK;
            

        [Theory, AutoData]
        public void GetProjects(Infrastructure.Project.MockProjectService service)
        {
            var controller = new Proxy.Controllers.ProjectsController(service);
            var result = controller.GetProjects();

            Assert.IsType<ActionResult<GetProjectsWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as GetProjectsWrapperResponse)?.source);
            Assert.Equal(code, (result.Value as GetProjectsWrapperResponse)?.code);
            AssertUnhandledExceptionsGetProjects(createSource, result);
        }

        [Theory, AutoData]
        public void AddProject(Create model, Infrastructure.Project.MockProjectService service) 
        {
            var controller = new Proxy.Controllers.ProjectsController(service);
            var result = controller.AddProject(model);

            Assert.IsType<ActionResult<CreateWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as CreateWrapperResponse)?.source);
            Assert.Equal(createdCode, (result.Value as CreateWrapperResponse)?.code);
            Assert.Equal("Project Created Succesfully", (result.Value as CreateWrapperResponse)?.message);
            AssertUnhandledExceptionsAddProjects(createSource, result);
        }

        [Theory, AutoData]
        public void DeleteProject(int id, Infrastructure.Project.MockProjectService service)
        {
            var controller = new Proxy.Controllers.ProjectsController(service);
            var result = controller.DeleteProject(id);

            Assert.IsType<ActionResult<DeleteWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as DeleteWrapperResponse)?.source);
            Assert.Equal(updatedCode, (result.Value as DeleteWrapperResponse)?.code);
            Assert.Equal("Project Deleted Succesfully", (result.Value as DeleteWrapperResponse)?.message);
            AssertUnhandledExceptionsDeleteProjects(createSource, result);
        }

        [Theory, AutoData]
        public void UpdateProject(Update model, Infrastructure.Project.MockProjectService service)
        {
            var controller = new Proxy.Controllers.ProjectsController(service);
            var result = controller.UpdateProject(model);

            Assert.IsType<ActionResult<UpdateWrapperResponse>>(result);
            Assert.Equal(createSource, (result.Value as UpdateWrapperResponse)?.source);
            Assert.Equal(updatedCode, (result.Value as UpdateWrapperResponse)?.code);
            Assert.Equal("Project Updated Succesfully", (result.Value as UpdateWrapperResponse)?.message);
            AssertUnhandledExceptionsUpdateProjects(createSource, result);
        }


        private static void AssertUnhandledExceptionsGetProjects(string source, ActionResult<GetProjectsWrapperResponse> result)
        {
            Assert.IsType<ActionResult<GetProjectsWrapperResponse>>(result);
            Assert.Equal(source, (result.Value as GetProjectsWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsAddProjects(string source, ActionResult<CreateWrapperResponse> result)
        {
            Assert.IsType<ActionResult<CreateWrapperResponse>>(result);
            Assert.IsType<CreateWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as CreateWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsDeleteProjects(string source, ActionResult<DeleteWrapperResponse> result)
        {
            Assert.IsType<ActionResult<DeleteWrapperResponse>>(result);
            Assert.IsType<DeleteWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as DeleteWrapperResponse)?.source);
        }

        private static void AssertUnhandledExceptionsUpdateProjects(string source, ActionResult<UpdateWrapperResponse> result)
        {
            Assert.IsType<ActionResult<UpdateWrapperResponse>>(result);
            Assert.IsType<UpdateWrapperResponse>(result.Value);
            Assert.Equal(source, (result.Value as UpdateWrapperResponse)?.source);
        }
    }
}
