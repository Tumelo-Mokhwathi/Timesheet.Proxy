using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models
{
    public class DeleteWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }
        public int project { get; set; }
        public string source { get; set; } 

        public DeleteWrapperResponse(HttpStatusCode Code, string Message, int Project, string Source)
        {
            code = Code;
            message = Message;
            project = Project;
            source = Source;
        }
    }
}
