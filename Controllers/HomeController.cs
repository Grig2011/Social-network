using System.Diagnostics;
using DevNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string language = "UserCulture";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ChangeLanguage() { return View(); }
        [HttpPost]
        public IActionResult ChangeLanguage(string lang)
        {
            Response.Cookies.Append(language, lang, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax
            });
            return RedirectToAction("Index");

        }
    }
}
