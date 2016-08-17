using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Dixus.WebUI.Infrastructure.Extensions;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System;

namespace Dixus.WebUI.Infrastructure
{
    public class LoginInfoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IUserRepository userrepo = new UserRepository();
                string username = actionContext.HttpContext.User.Identity.Name;
                actionContext.Controller.ViewBag.Usuario = username.ToLower().PrimeraLetraMayuscula();
                actionContext.Controller.ViewBag.UserId = actionContext.HttpContext.User.Identity.GetUserId();
                //actionContext.Controller.ViewBag.Role = userrepo.ObtenerRolesDeUsuario(actionContext.HttpContext.User.Identity.GetUserId());

            }
        }
    }
}