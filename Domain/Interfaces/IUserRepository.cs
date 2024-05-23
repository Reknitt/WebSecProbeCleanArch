using Presentation.Domain.Entities.UserEntities;

namespace Presentation.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);
        Task<int> UpdateAsync(User user);
        Task<int> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(string name);
        Task<User> GetByEmailAsync(string email);
        Task<User?> GetByLoginAndPasswordAsync(string name, string password);
    }
}
