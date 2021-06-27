using BugetPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugetPlanner.Database
{
    public class InkomstUitgaveDbContext: DbContext
    {
        public InkomstUitgaveDbContext(DbContextOptions<InkomstUitgaveDbContext> options) : base(options)
        {

        }
        public DbSet<InkomstUitgave> InkomstUitgave { get; set; }
    }
}
