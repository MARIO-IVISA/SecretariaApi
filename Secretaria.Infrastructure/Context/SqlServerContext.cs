using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secretaria.Api.Settings;
using Secretaria.Domain.Entities;
using Secretaria.Infrastructure.Mappings;

namespace Secretaria.Infrastructure.Context
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(AppSettings.ConnectionStrings);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatriculaMap());
       
        }

        public DbSet<Matricula>? Matricula { get; set; }

    }
}

