﻿using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dixus.WebUI.Controllers
{
    public class SubdivisionesController : Controller
    {
        private IUnitOfWork uow;
        public SubdivisionesController(IUnitOfWork uowparam)
        {
            uow = uowparam;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FraccionLegal subdivision = uow.SubdivisionesLegales.ObtenerPorId( sub => sub.FraccionLegalId == id.Value, "Clientes", "EscrituraDeSubdivision");
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }
        
        public ActionResult TablaSubdivisiones(int? escrituraSubdivisionId)
        {
            IEnumerable<FraccionLegal> subdivisiones; 

            if ( escrituraSubdivisionId == null)
            {
                subdivisiones = uow.SubdivisionesLegales.Obtener("EscrituraDeSubdivision");     
            }
            else
            {
                subdivisiones = uow.SubdivisionesLegales.Filtrar(sub => sub.EscrituraSubdivisionId == escrituraSubdivisionId.Value, "EscrituraDeSubdivision");
            }

            subdivisiones.OrderBy(x => x.FechaDeOtorgamiento);

            return View(subdivisiones);
        }

    }
}