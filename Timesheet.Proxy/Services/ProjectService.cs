using System;
using System.Collections.Generic;
using System.Linq;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Project;
using Timesheet.Proxy.Services.Interfaces;

namespace Timesheet.Proxy.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TimesheetContext _context;

        public ProjectService(TimesheetContext context)
        {
            _context = context;
        }

        public Projects[] GetAllProjects()
        {
            var allProjects = (from project in _context.Projects select project).ToArray();
            return allProjects;
        }
        public Projects AddProject(Create addProject)
        {
            var project = new Projects
            {
                ProjectName = addProject.ProjectName,
                ProjectCode = addProject.ProjectCode,
                Comment = addProject.Comment
            }; 

            _context.Add(project);
            _context.SaveChanges();

            return project;
        }
        public object DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);

            _context.Projects.Remove(project);
            return _context.SaveChanges();
        }

        public Projects GetById(int id)
        {
            var project = _context.Projects.Find(id);

            if(project == null)
            {
                throw new KeyNotFoundException("Project not Found with specified ID");
            }

            return project;
        }

        public Projects Update(Update updateProject)
        {
            var project = GetById(updateProject.ProjectId);

            if(project.ProjectName != updateProject.ProjectName 
                && _context.Projects.Any(c => c.ProjectName.Equals(updateProject.ProjectName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException("Project already exists");
            }

            project.ProjectName = updateProject.ProjectName;
            project.ProjectCode = updateProject.ProjectCode;
            project.Comment = updateProject.Comment;

            _context.Update(project);
            _context.SaveChanges();

            return project;
        }
    }
}
