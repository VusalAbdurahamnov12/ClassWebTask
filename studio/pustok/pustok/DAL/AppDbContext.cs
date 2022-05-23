using Microsoft.AspNetCore.Mvc;

namespace pustok.DAL
{
    public class AppDbContext : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
