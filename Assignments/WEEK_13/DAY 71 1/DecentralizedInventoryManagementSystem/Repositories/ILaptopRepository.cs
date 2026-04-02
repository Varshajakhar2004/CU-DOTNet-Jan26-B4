using DecentralizedInventoryManagementSystem.Models;

namespace DecentralizedInventoryManagementSystem.Repositories
{
    public interface ILaptopRepository
    {
        Task<List<Laptop>> GetAsync();
        Task CreateAsync(Laptop laptop);
    }
}
