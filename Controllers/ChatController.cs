using Microsoft.AspNetCore.Mvc;

namespace DevNet.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
