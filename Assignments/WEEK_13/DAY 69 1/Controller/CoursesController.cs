using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEEK_13.Data;
using WEEK_13.DTOs;
using WEEK_13.Models;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Courses.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CourseDTO dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Credits = dto.Credits
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return Ok(course);
    }
}