using Microsoft.EntityFrameworkCore;
using RegCitas.Entidades;
using System;

namespace RegCitas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Citas> Citas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Citas.db");
        }
    }
}
