using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
