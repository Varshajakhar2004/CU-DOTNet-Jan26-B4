using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult MyCourses()
        {
            return View();
        }
    }
}
