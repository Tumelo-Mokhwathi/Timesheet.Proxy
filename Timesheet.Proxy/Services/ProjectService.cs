using System;
using System.Linq;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Services.Interfaces;

namespace Timesheet.Proxy.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TimesheetContext _context = new TimesheetContext();
        public object AddProject(AllProjects addProject)
        {
            _context.AllProjects.Add(addProject);
            return _context.SaveChanges();
        }
        public int DeleteProject(int id)
        {
            var project = (from r in _context.AllProjects
                           where r.ProjectId == id
                           select r).SingleOrDefault();

            _context.AllProjects.Remove(project);
            return _context.SaveChanges();
        }
        public AllProjects[] GetAllProjects()
        {
            var allProjects = (from project in _context.AllProjects select project).ToArray();
            return allProjects;
        }
    }
}
