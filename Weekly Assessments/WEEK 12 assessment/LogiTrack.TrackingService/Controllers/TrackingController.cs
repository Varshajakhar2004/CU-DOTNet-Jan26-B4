using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tracking")]
public class TrackingController : ControllerBase
{
    [HttpGet("gps")]
    [Authorize(Roles = "Manager")]
    public IActionResult GetGpsData()
    {
        return Ok(new
        {
            TruckId = "TRK123",
            Location = "28.6139° N, 77.2090° E",
            Status = "On Route"
        });
    }
}