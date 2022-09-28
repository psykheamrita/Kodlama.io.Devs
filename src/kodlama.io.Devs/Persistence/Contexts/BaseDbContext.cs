using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration;

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pL =>
            {
                pL.ToTable("ProgrammingLanguages").HasKey(pL => pL.Id);
                pL.Property(pL => pL.Id).HasColumnName("Id");
                pL.Property(pL => pL.Name).HasColumnName("Name");
            });
            ProgrammingLanguage[] programmingLanguagesSeed = { new(1, "C#"), new( 2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeed);
        }
    }
}
