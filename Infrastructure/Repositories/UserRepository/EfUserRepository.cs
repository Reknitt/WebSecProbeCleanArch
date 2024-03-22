using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities.UserEntities;
using Presentation.Domain.Interfaces;
using WebSecProbeCleanArch.Infrastructure.DbContexts;

namespace WebSecProbeCleanArch.Infrastructure.Repositories.UserRepository
{
    public class EfUserRepository : IUserRepository
    {
        private readonly IDbContextFactory<SqliteDbContext> _dbContextFactory;

        public EfUserRepository(IDbContextFactory<SqliteDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<int> CreateAsync(User user)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var addedUser = await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return addedUser.Entity.Id;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = await context.Users.FindAsync(id);
                // сделать проверку на null
                return user;
            }
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
