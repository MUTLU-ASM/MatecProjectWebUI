using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
