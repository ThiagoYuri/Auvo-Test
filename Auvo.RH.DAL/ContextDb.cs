using Auvo.RH.DAL.Models;
using Auvo.RH.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Auvo.RH.DAL
{
    public class ContextDb : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<TempoTrabalhado> TempoTrabalhado { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Auvo;Data Source=THIAGOYURI;TrustServerCertificate=True");
            }
        }
    }
}
