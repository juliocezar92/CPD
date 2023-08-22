using CPD.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPD.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly UserManager<CPDUser> _userManager;
        public LoginController(UserManager<CPDUser> userManager) 
        {
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewData["UserId"] = _userManager.GetUserId(this.User);
            return View();
        }
    }
}
