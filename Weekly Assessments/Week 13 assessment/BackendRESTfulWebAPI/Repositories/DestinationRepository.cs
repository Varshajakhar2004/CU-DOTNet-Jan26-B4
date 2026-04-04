using BackendRESTfulWebAPI.Exceptions;
using BackendRESTfulWebAPI.Models;
using BackendRESTfulWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
public class DestinationRepository : IDestinationRepository
{
    private readonly AppDbContext _context;

    public DestinationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await _context.Destinations.ToListAsync();
    }

    public async Task<Destination> GetByIdAsync(int id)
    {
        var data = await _context.Destinations.FindAsync(id);

        if (data == null)
            throw new DestinationNotFoundException("Destination not found");

        return data;
    }

    public async Task AddAsync(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Destination destination)
    {
        _context.Destinations.Update(destination);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await GetByIdAsync(id);
        _context.Destinations.Remove(data);
        await _context.SaveChangesAsync();
    }
}