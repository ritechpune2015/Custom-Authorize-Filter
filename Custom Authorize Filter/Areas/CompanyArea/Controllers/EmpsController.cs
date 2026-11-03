using Custom_Authorize_Filter.CustFilter;
using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.Repositories;
using Custom_Authorize_Filter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Custom_Authorize_Filter.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [UserAuth]
    public class EmpsController : Controller
    {
        IEmpRepo repo;
        public EmpsController(IEmpRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));

            return View(await this.repo.GetAll(companyid));
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpCreateVM rec)
        { 
           if(ModelState.IsValid)
            {
                rec.CompanyID =Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
               await this.repo.Insert(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        
    }
}
