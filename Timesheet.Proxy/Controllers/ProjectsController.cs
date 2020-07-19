using Microsoft.AspNetCore.Mvc;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.Services;
using Timesheet.Proxy.Models;
using System.Net;
using System;
using Timesheet.Proxy.Models.Project;

namespace Timesheet.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _IProjectService;

        public ProjectsController(IProjectService projectService)
        {
            _IProjectService = projectService;
        }

        [HttpGet("GetAllProjects")]
        public ActionResult<GetProjectsWrapperResponse> GetProjects()
        {
            var code = HttpStatusCode.OK;
            var projects = _IProjectService.GetAllProjects();
            var source = $"{Constants.Source.ProjectsPrefixName}";

            try
            {
                return new GetProjectsWrapperResponse(code, projects, source);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPost("AddProject")]
        public ActionResult<CreateWrapperResponse> AddProject(Create model) 
        {
            var code = HttpStatusCode.Created;
            var message = $"{Constants.Message.ProjectCreatedMessage}";
            var projects = _IProjectService.AddProject(model);
            var source = $"{Constants.Source.ProjectsPrefixName}";

            try
            {
                return new CreateWrapperResponse(code, message, projects, source);
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateProject")]
        public ActionResult<UpdateWrapperResponse> UpdateProject(Update model)
        {
            var code = HttpStatusCode.OK;
            var message = $"{Constants.Message.ProjectUpdateMessage}";
            var projects = _IProjectService.Update(model);
            var source = $"{Constants.Source.ProjectsPrefixName}";

            try
            {
                return new UpdateWrapperResponse(code, message, projects, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteProject/{id}")]
        public ActionResult<DeleteWrapperResponse> DeleteProject([FromRoute] int id)
        {
            var code = HttpStatusCode.OK;
            var message = $"{Constants.Message.ProjectDeletedMessage}";
            var projects = _IProjectService.DeleteProject(id);
            var source = $"{Constants.Source.ProjectsPrefixName}";

            try
            {
                return new DeleteWrapperResponse(code, message, projects, source);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}