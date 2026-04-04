using FrontendMVCIntegration.Models;
namespace FrontendMVCIntegration.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();

        Task AddAsync(Destination destination);
    }

}
