using ControleDespesa5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions <AplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovimentosDR>().HasKey(t => t.Id);
            modelBuilder.Entity<Despesa>().HasKey(t => t.Id);
            modelBuilder.Entity<Receita>().HasKey(t => t.Id);
            modelBuilder.Entity<MovimentosDR>().HasOne(t => t.Despesa);


        }
        public DbSet<ControleDespesa5.Models.MovimentosDR> MovimentosDR { get; set; }
        public DbSet<ControleDespesa5.Models.Despesa> Despesa { get; set; }
        public DbSet<ControleDespesa5.Models.Receita> Receita { get; set; }
    }
}
