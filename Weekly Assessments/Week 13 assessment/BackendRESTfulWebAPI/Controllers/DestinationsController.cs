using BackendRESTfulWebAPI.Models;
using BackendRESTfulWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationRepository _repo;

    public DestinationsController(IDestinationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _repo.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(Destination d)
    {
        await _repo.AddAsync(d);
        return Ok(d);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Destination d)
    {
        if (id != d.Id) return BadRequest();

        await _repo.UpdateAsync(d);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}