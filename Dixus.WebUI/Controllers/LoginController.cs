using Dixus.WebUI.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Dixus.Repositorios.Abstract;
using System.Diagnostics;

namespace Dixus.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userrepo;
        public LoginController(IUserRepository userrepo)
        {
            _userrepo = userrepo;
        }

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "home");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(LoginViewModel model, string returnUrl)
        {
            try
            {
                ClaimsIdentity identity = await _userrepo.Login(model.User, model.Password);
                var ctx = Request.GetOwinContext();
                ctx.Authentication.SignIn(identity);
                return Redirect(String.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            var owinContext = Request.RequestContext.HttpContext.GetOwinContext();
            
            if (owinContext.Authentication.User.Identity.IsAuthenticated)
                owinContext.Authentication.SignOut();
            
            return Redirect("/Login");
        }

    }
}