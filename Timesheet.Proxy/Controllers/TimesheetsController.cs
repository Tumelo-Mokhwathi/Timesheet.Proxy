using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.Services;
using Timesheet.Proxy.Models;
using System.Net;
using Timesheet.Proxy.Models.Timesheet;

namespace Timesheet.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly ITimesheetService _ITimesheetService;

        public TimesheetsController(ITimesheetService timesheetService)  
        {
            _ITimesheetService = timesheetService;
        }

        [HttpGet("GetAllTimesheets")]
        public ActionResult<GetTimesheetsWrapperResponse> GetTimesheets()
        {
            var code = HttpStatusCode.OK;
            var timesheets = _ITimesheetService.GetAllTimesheets();
            var source = $"{Constants.Source.TimesheetPrefixName}";

            try
            {
                return new GetTimesheetsWrapperResponse(code, timesheets, source);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPost("AddTimesheet")]
        public ActionResult<AddTimesheetWrapperResponse> AddTimesheets(Create model)
        {
            var code = HttpStatusCode.Created;
            var message = $"{Constants.Message.TimesheetCreatedMessage}";
            var timesheet = _ITimesheetService.AddTimesheet(model);
            var source = $"{Constants.Source.TimesheetPrefixName}";

            try
            {
                return new AddTimesheetWrapperResponse(code, message, timesheet, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteTimesheet/{id}")]
        public ActionResult<DeleteWrapperResponse> DeleteTimesheet([FromRoute] int id)
        {
            var code = HttpStatusCode.OK;
            var message = $"{Constants.Message.TimesheetDeletedMessage}";
            var timesheet = _ITimesheetService.DeleteTimesheet(id);
            var source = $"{Constants.Source.TimesheetPrefixName}";

            try
            {
                return new DeleteWrapperResponse(code, message, timesheet, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateTimesheet")]
        public ActionResult<UpdateWrapperResponse> UpdateTimesheet(Update model)
        {
            var code = HttpStatusCode.OK; 
            var message = $"{Constants.Message.TimesheetUpdateMessage}";
            var timesheet = _ITimesheetService.Update(model);
            var source = $"{Constants.Source.TimesheetPrefixName}";

            try
            {
                return new UpdateWrapperResponse(code, message, timesheet, source);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}