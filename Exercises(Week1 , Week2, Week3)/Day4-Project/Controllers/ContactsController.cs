using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult MyContact()
        {
            return View();
        }
    }
}
