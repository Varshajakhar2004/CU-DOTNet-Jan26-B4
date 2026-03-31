using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEEK_13.Data;
using WEEK_13.DTOs;
using WEEK_13.Models;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _context.Students.ToListAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentDTO dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            Age = dto.Age
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, StudentDTO dto)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();

        student.Name = dto.Name;
        student.Email = dto.Email;
        student.Age = dto.Age;

        await _context.SaveChangesAsync();
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}