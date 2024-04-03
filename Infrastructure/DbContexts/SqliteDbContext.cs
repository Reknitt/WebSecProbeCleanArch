using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities.UserEntities;
using Presentation.Domain.Entities.VulnerabilityEntities;
using System.Collections.Generic;

namespace WebSecProbeCleanArch.Infrastructure.DbContexts
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Vulnerability> Vulnerabilities => Set<Vulnerability>();

        public SqliteDbContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vulnerability>()
                .HasMany(p => p.Attacks)
                .WithOne(p => p.Vulnerability)
                .HasForeignKey(p => p.VulnerabilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
