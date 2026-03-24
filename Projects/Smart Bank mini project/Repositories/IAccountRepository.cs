using SmartBankMiniProject.Models;

namespace SmartBankMiniProject.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> AddAsync(Account account);
        Task<List<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task UpdateAsync(Account account);
    }
}
