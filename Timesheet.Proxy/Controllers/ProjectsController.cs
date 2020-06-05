using Microsoft.AspNetCore.Mvc;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.Services;
using Timesheet.Proxy.Models;
using System.Net;
using System;

namespace Timesheet.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _IProjectService;

        public ProjectsController()
        {
            _IProjectService = new ProjectService();
        }

        [HttpGet("GetAllProjects")]
        public ActionResult<GetProjectsWrapperResponse> GetProjects()
        {
            var code = HttpStatusCode.OK;
            var projects = _IProjectService.GetAllProjects();
            var source = $"{Constants.Source.TimesheetProjectsPrefixName}";

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
        public ActionResult<CreateWrapperResponse> AddProject(AllProjects project) 
        {
            var code = HttpStatusCode.Created;
            var message = $"{Constants.Message.CreatedMessage}";
            var projects = _IProjectService.AddProject(project);
            var source = $"{Constants.Source.TimesheetProjectsPrefixName}";

            try
            {
                return new CreateWrapperResponse(code, message, projects, source);
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
            var message = $"{Constants.Message.DeletedMessage}";
            var projects = _IProjectService.DeleteProject(id);
            var source = $"{Constants.Source.TimesheetProjectsPrefixName}";

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