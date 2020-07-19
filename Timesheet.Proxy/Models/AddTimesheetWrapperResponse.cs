using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models
{
    public class AddTimesheetWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }
        public object timesheet { get; set; }
        public string source { get; set; }

        public AddTimesheetWrapperResponse(HttpStatusCode Code, string Message, object Timesheet, string Source)
        {
            code = Code;
            message = Message;
            timesheet = Timesheet;
            source = Source;
        }
    }
}
