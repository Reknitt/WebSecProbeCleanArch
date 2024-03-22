using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities.UserEntities;
using System.Collections.Generic;

namespace WebSecProbeCleanArch.Infrastructure.DbContexts
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public SqliteDbContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
}
