using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Simurgh.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Helpers
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SimurghDB>
    {
        public SimurghDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimurghDB>();
            optionsBuilder.UseSqlite("Data Source=Simurgh1.db");

            return new SimurghDB(optionsBuilder.Options);
        }
    }
}
