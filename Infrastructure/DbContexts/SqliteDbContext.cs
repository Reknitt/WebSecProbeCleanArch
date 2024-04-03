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
        public DbSet<ExampleOfAttack> ExamplesOfAttack => Set<ExampleOfAttack>();

        public SqliteDbContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vulnerability>()
                .HasMany(p => p.Attacks) // у Vulnerability много сценариев аттак
                .WithOne(p => p.Vulnerability) // у сценариев атак одна Vulnerability
                .HasForeignKey(p => p.VulnerabilityId)
                .OnDelete(DeleteBehavior.Cascade); // каскадное удаление связанных таблиц

            modelBuilder.Entity<ExampleOfAttack>()
                .HasMany(p => p.StepsOfAttack)
                .WithOne(p => p.ExampleOfAttack)
                .HasForeignKey(p => p.ExampleOfAttackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
