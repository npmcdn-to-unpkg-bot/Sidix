using Dixus.BusinessRules.CambiosAutocad.Abstract;
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

namespace Dixus.WebUI.Controllers
{
    public class FraccionesGeoJsonController : ApiController
    {

        // GET: api/FraccionesGeoJson
        public JsonResult<object> Get()
        {

            IUnitOfWork uow = new UnitOfWork();
            IGeoJsonGenerator generadorGeoJson = new GeoJsonGenerator();
            IEnumerable<Fraccion> Fracciones = uow.Fracciones.Obtener("TipoDeSuelo");

            object obj = new {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "EPSG:32612",
                    }
                },
                features = generadorGeoJson.TransformarFraccionesAGeoJson(fracciones: Fracciones)
            };

            return Json(obj);
        }

        // GET: api/GeoJsonApi/5
        public JsonResult<object> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/GeoJsonApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GeoJsonApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GeoJsonApi/5
        public void Delete(int id)
        {
        }
    }
}
