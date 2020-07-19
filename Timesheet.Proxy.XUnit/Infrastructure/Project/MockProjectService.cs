using System;
using System.Collections.Generic;
using System.Text;
using Timesheet.Proxy.Models;
using Timesheet.Proxy.Models.Project;
using Timesheet.Proxy.Services.Interfaces;

namespace Timesheet.Proxy.XUnit.Infrastructure.Project
{
    public class MockProjectService : IProjectService
    {
        public Projects[] GetAllProjects()
        {
            Projects[] projects = new Projects[]
            {
                NewProject(),
                NewProject()
            };

            projects[1].ProjectId = 1;
            return projects;
        }
        public Projects AddProject(Create addProject)
        {
            return new Projects
            {
                ProjectId = 1,
                ProjectName = addProject.ProjectName,
                ProjectCode = addProject.ProjectCode,
                Comment = addProject.Comment,
            };
        }

        public Projects GetById(int id)
        {
            return NewProject();
        }

        public object DeleteProject(int id)
        {
            return NewProject();
        }
        public Projects Update(Update updateProject)
        {
            return new Projects
            {
                ProjectId = updateProject.ProjectId,
                ProjectName = updateProject.ProjectName,
                ProjectCode = updateProject.ProjectCode,
                Comment = updateProject.Comment,
            };
        }

        private static Projects NewProject()
        {
            return new Projects
            {
                ProjectId = 1,
                ProjectName = "MTN",
                ProjectCode = "TD2020",
                Comment = "Project added",
            };
        }
        private static Projects NewProjects()
        {
            return new Projects
            {
                ProjectId = 1,
                ProjectName = "MTN",
                ProjectCode = "TD2020",
                Comment = "Project added",
            };
        }
    }
}
