using Microsoft.AspNetCore.Mvc;
using pustok.DAL;
using pustok.Models;
using System.Collections.Generic;
using System.Linq;

namespace pustok.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _contexct { get; }
        public HomeController(AppDbContext context)
        {
            _contexct = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _contexct.Sliders.ToList();
            return View(sliders);
        }
    }
}
