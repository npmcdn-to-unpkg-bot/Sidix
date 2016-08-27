using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Dixus.WebUI.Controllers.WebApi
{
    [RoutePrefix("/api/tareas")]
    public class TareasController : ApiController
    {

        public JsonResult<IEnumerable<Tarea>> Get()
        {
            IUnitOfWork uow = new UnitOfWork();
            string currentUserName = RequestContext.Principal.Identity.Name;

            var tareas = uow.Tareas.ObtenerTareasPorUsuario(currentUserName);
            return Json(tareas);
        }

    }
}
