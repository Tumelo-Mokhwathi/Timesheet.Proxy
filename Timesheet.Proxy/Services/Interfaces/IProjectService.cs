using System;
using System.Collections.Generic;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Project;

namespace Timesheet.Proxy.Services.Interfaces
{
    public interface IProjectService
    {
        Projects[] GetAllProjects();
        Projects AddProject(Create addProject);
        Projects GetById(int id);
        object DeleteProject(int id);
        Projects Update(Update updateProject);
    }
}
