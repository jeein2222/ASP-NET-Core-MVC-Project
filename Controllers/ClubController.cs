using Microsoft.AspNetCore.Mvc;
using NETCoreMVCProject.interfaces;
using NETCoreMVCProject.Models;
using NETCoreMVCProject.ViewModels;

namespace NETCoreMVCProject.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService){
            this._clubRepository = clubRepository;
            this._photoService = photoService;  
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id){
            //Include는 Clubs 테이블과 연관된 Address 테이블을 함게 로드한다.
            //FirstOrDefault 조건에 맞는 첫번째 클럽을 반환하거나, 없다면 null을 반환한다.
            //Club club = _context.Clubs.Include(a=>a.Address).FirstOrDefault(c => c.Id == id);

            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM){
            if(!ModelState.IsValid){ //제출된 데이터가 모델의 요구 사항과 일치하는지 
               var result= await _photoService.AddPhotoAsync(clubVM.Image);
                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image=result.Url.ToString(),
                    Address=new Address{
                        Street= clubVM.Address.Street,
                        City=clubVM.Address.City,
                        State=clubVM.Address.State
                    },
                    ClubCategory=clubVM.ClubCategory

                };
                _clubRepository.Add(club);
                return RedirectToAction("Index");
            }else{
                ModelState.AddModelError("", "Photo upload failed.");
            }
            return View(clubVM);

        }
    }
}
