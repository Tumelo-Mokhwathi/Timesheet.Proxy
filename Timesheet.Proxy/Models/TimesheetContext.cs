﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheet.Proxy.Models
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext(DbContextOptions<TimesheetContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //                                            .AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();
        //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ApplicationConnection"]);
        //}

        public DbSet<Projects> Projects { get; set; } 
        public DbSet<Timesheets> Timesheets { get; set; }
    }
}
