using Microsoft.AspNetCore.Mvc;
using WEEK_13.Data;
using WEEK_13.DTOs;
using WEEK_13.Models;

[Route("api/enroll")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Enroll(EnrollDTO dto)
    {
        var studentExists = await _context.Students.FindAsync(dto.StudentId);
        var courseExists = await _context.Courses.FindAsync(dto.CourseId);

        if (studentExists == null || courseExists == null)
            return BadRequest("Invalid Student or Course");

        var enrollment = new StudentCourse
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };

        _context.StudentCourses.Add(enrollment);
        await _context.SaveChangesAsync();

        return Ok("Enrolled Successfully");
    }
}