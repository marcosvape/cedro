using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroAPI.Models
{
    public class CedroContextFactory : IDesignTimeDbContextFactory<CedroContext>
    {
        
        private const string CONNECTION_STRING = @"User Id=admin;Password=ttCHANGE12345;Server=escoladb.ctxv6h9crnxh.us-east-1.rds.amazonaws.com;Database=Cedro;";

        public CedroContext CreateDbContext(string[] args)
        {
            var constructor = new DbContextOptionsBuilder<CedroContext>();
            constructor.UseMySql(CONNECTION_STRING);
            return new CedroContext(constructor.Options);
        }
    }
}
