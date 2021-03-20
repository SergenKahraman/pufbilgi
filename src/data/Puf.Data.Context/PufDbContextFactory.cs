using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puf.Data.Context
{
    public class PufDbContextFactory : IDesignTimeDbContextFactory<PufDbContext>
    {
        public PufDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.;Database=PufDb;User Id=pufadmin;Password=sk3637";
            var builder = new DbContextOptionsBuilder().UseSqlServer(connectionString);
            return new PufDbContext(builder.Options);
        }
    }
}
