using Microsoft.AspNetCore.Mvc;

namespace MatecProjectWebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
