using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.Repositories;
using Custom_Authorize_Filter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Custom_Authorize_Filter.Controllers
{
    public class ManageUsersController : Controller
    {
        IUser repo;
        public ManageUsersController(IUser repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.repo.Login(rec);
                if (res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("CompanyName", res.FullName);
                    
                    HttpContext.Session.SetString("CompanyID", res.LoggedInUserID.ToString());

                    return RedirectToAction("Index", "CompanyHome", new { area = "CompanyArea" });
                }
                else
                {
                    ModelState.AddModelError("", res.ProblemMesssage);
                }
            }

            return View(rec);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Company rec)
        {
            if (ModelState.IsValid)
            {
                await this.repo.Register(rec);
                return RedirectToAction("Login");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
