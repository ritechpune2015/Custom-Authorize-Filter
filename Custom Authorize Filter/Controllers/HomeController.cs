using Microsoft.AspNetCore.Mvc;

namespace Custom_Authorize_Filter.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
