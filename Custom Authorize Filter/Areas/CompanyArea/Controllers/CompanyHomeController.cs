using Custom_Authorize_Filter.CustFilter;
using Microsoft.AspNetCore.Mvc;

namespace Custom_Authorize_Filter.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [UserAuth]
    public class CompanyHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
