using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AadhaarVerification.Models
{
    public class VerifyDbContext:DbContext
    {
        public VerifyDbContext(DbContextOptions<VerifyDbContext> options) : base(options) { }
        
            public virtual DbSet<Data> Data { get; set; }
        
    }
}
