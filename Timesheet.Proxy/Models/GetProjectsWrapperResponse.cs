using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Timesheet.Proxy.Models
{
    public class GetProjectsWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public AllProjects[] projects { get; set; }
        public string source { get; set; }

        public GetProjectsWrapperResponse(HttpStatusCode Code, AllProjects[] Projects, string Source)
        {
            code = Code;
            projects = Projects;
            source = Source;
        }
    }
}
