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
        public object item { get; set; }
        public string source { get; set; } 

        public DeleteWrapperResponse(HttpStatusCode Code, string Message, object Item, string Source)
        {
            code = Code;
            message = Message;
            item = Item;
            source = Source;
        }
    }
}
