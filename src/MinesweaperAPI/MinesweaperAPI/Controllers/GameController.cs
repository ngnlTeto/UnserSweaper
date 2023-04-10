using Microsoft.AspNetCore.Mvc;

namespace MinesweaperAPI.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
