using Microsoft.AspNetCore.Mvc;
using NETCoreMVCProject.Data;

namespace NETCoreMVCProject.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context){
            this._context = context;
        }
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }
}
