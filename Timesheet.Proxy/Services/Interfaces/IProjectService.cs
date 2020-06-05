using System;
using Timesheet.Proxy.Models;

namespace Timesheet.Proxy.Services.Interfaces
{
    public interface IProjectService
    {
        object AddProject(AllProjects addProject);
        int DeleteProject(int id);   
        AllProjects[] GetAllProjects();
    }
}
