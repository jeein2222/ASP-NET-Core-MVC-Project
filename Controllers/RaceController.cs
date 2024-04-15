using Microsoft.AspNetCore.Mvc;

namespace NETCoreMVCProject.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
