using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models.Project
{
    public class Update
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectCode { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
