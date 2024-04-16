using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCoreMVCProject.Data;
using NETCoreMVCProject.interfaces;
using NETCoreMVCProject.Models;
using NETCoreMVCProject.Repository;

namespace NETCoreMVCProject.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        public RaceController(IRaceRepository repository){
            _raceRepository = repository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id){
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            { //제출된 데이터가 모델의 요구 사항과 일치하는지 
                return View(race);
            }
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }

    }
}
