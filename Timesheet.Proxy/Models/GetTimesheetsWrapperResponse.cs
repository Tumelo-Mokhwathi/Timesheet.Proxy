using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models
{
    public class GetTimesheetsWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public Timesheets[] timesheets { get; set; }
        public string source { get; set; }

        public GetTimesheetsWrapperResponse(HttpStatusCode Code, Timesheets[] Timesheets, string Source)
        {
            code = Code;
            timesheets = Timesheets; 
            source = Source;
        }
    }
}
