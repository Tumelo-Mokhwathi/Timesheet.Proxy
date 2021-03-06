﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Timesheet.Proxy.Models
{
    public class CreateWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }
        public object item { get; set; }
        public string source { get; set; }

        public CreateWrapperResponse(HttpStatusCode Code, string Message, object Item, string Source) 
        {
            code = Code;
            message = Message;
            item = Item;
            source = Source;
        } 
    }
}
