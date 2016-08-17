using Dixus.BusinessRules.CambiosAutocad.Abstract;
using Dixus.BusinessRules.CambiosAutocad.Concrete;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Dixus.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dixus.Tests
{
    


    [TestClass]
    public class ExampleClass
    {
        [TestMethod]
        public void GenerarTablaFracciones()
        {
            var hola = Type.GetType("Dixus.Entidades.FraccionCOM, Dixus.Entidades");
            var myobject = Activator.CreateInstance(hola);
            Assert.IsInstanceOfType(myobject, typeof(FraccionCOM));
        }

        [TestMethod]
        public void ChecarFuncionamientoDeOrdenarPorFecha()
        {
            Evento[] eventos = new Evento[]
            {
                new Evento() { Fecha = new DateTime(2000,1,1) },
                new Evento() { Fecha = new DateTime(2010,1,1) },
                new Evento() { Fecha = new DateTime(2020,1,1) },
            };

            Evento[] eventosOrdenados = eventos.OrderByDescending(ev => ev.Fecha).ToArray();
            Assert.AreEqual<int>(eventosOrdenados[0].Fecha.Year, 2020);
        }

       

        

        //[TestMethod]
        //public void ChecarFuncionamientoDeDbGeometry()
        //{
        //    IGisRepository gisRepo = new GisRepository();
        //    var fracciones = gisRepo.ObtenerFracciones();

        //    ITransformadorDeGeometriaAGeoJson transformador = new TransformadorDeGeometriaAGeoJson();

        //    List<FraccionesConInfoDePuntos> lista = new List<FraccionesConInfoDePuntos>();
        //    foreach(var fracc in fracciones)
        //    {
        //        lista.Add(new FraccionesConInfoDePuntos()
        //        {
        //            Nombre = fracc.Nombre,
        //            ArrayDePuntos = transformador.ConvertirPoligonoEnCoordinadasGeoJson(fracc.Geometry)
        //        });
        //    }

        //    foreach( var item in lista)
        //    {
        //        Debug.WriteLine("Fraccion {0} tiene los siguientes puntos: ", item.Nombre);
        //        for (int i = 0; i < item.ArrayDePuntos.Length / 2; i++)
        //        {
        //            Debug.WriteLine("LAT: {0}, LNG: {1}",item.ArrayDePuntos[i,0], item.ArrayDePuntos[i,1]);
        //        }
        //        Debug.WriteLine("");
        //    }

        //    Assert.IsTrue(fracciones.Count() > 0);


        //}


    }

    public class FraccionesConInfoDePuntos
    {
        public string Nombre { get; set; }
        public double[,] ArrayDePuntos { get; set; }
    }

    public class Evento
    {
        public DateTime Fecha { get; set; }
    }

}
