using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bodyfactory.Models;

namespace bodyfactory.Data
{
    public class bodyfactoryContext : DbContext
    {
        public bodyfactoryContext (DbContextOptions<bodyfactoryContext> options)
            : base(options)
        {
        }

        public DbSet<bodyfactory.Models.Product> Product { get; set; }

        public DbSet<bodyfactory.Models.Distributor> Distributor { get; set; }

        public DbSet<bodyfactory.Models.Category> Category { get; set; }
    }
}
