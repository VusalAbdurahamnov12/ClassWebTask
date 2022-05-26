using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustok.DAL;
using pustok.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pustok.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Update(int id )
        {

            Slider slider = _context.Sliders.FirstOrDefault(x=>x.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Slider slider)
        {
            Slider SliderDb = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (SliderDb == null) return NotFound();
            SliderDb.SliderTitle1 = slider.SliderTitle1;
            SliderDb.SliderTitle2 = slider.SliderTitle2;
            SliderDb.Description = slider.Description;
            SliderDb.Image = slider.Image;
            SliderDb.RedirectUrlText = slider.RedirectUrlText;
            SliderDb.RedirectUrl = slider.RedirectUrl;
            _context.SaveChanges();
            return RedirectToAction("index");    
        }


        public IActionResult Delete(int id )
        {
            Slider slider = _context.Sliders.FirstOrDefault(x=>x.Id==id);
            if (slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Delete(Slider slider)
        //{
        //    _context.Sliders.Remove(slider);
        //    _context.Sliders.Remove(slider);
        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}
    }
}
