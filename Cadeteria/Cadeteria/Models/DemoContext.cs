using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class DemoContext: DbContext
    {
        public DbSet<Cadete> cadetes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source = C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria\Demo\Demo.db");
    }
}
