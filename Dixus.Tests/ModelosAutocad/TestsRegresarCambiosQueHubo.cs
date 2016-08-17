using Dixus.BusinessRules.CambiosAutocad.Abstract;
using Dixus.BusinessRules.CambiosAutocad.Concrete;
using Dixus.BusinessRules.CambiosAutocad.Entidades;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Tests.ModelosAutocad
{
    [TestClass]
    public class TestsRegresarCambiosQueHubo
    {
        [TestMethod]
        public void Detector_De_Cambios_Autocad_Regresa_Info_Correcta()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { FraccionId = 1, Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { FraccionId = 2, Nombre = "F2", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FraccionCOM { FraccionId = 3, Nombre = "F3", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) },
                new FraccionCOM { FraccionId = 4, Nombre = "F4", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 39 39, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { FraccionId = 5, Nombre = "F5", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 41 41, 20 40, 10 20, 30 10))",0) },
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "f9", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FeatureFraccion { Nombre = "f8", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) },
                new FeatureFraccion { Nombre = "F4", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 39 39, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F5", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 41 41, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F6", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) }
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-1", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var opciones = new OpcionesDeValidacionAutocad(){
                AreaTotalDelProyectoEnMetros = 10327709,
                ToleranciaEnM2ParaProyecto = 100
                //Demas opciones en blanco -> validar todo
            };


            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            //var esValido = detector.ChecarSiModeloAutocadEsValido(opciones).Result;
            var resumenCambios = detector.ObtenerResumenDeCambios().Result;

            // Assert
            //Assert.IsFalse(esValido);

            Assert.AreEqual(1, resumenCambios.ObtenerFraccionesQueNomasModificaronNombre().Count(), "Error en numero de fracciones que cambiaron de nombre");
            Assert.AreEqual(1, resumenCambios.ObtenerFraccionesQueNomasModificaronUsoDeSuelo().Count(), "Error en numero de fracciones que cambiaron de uso de suelo");
            Assert.AreEqual(1, resumenCambios.ObtenerFraccionesQueModificaronNombreYUso().Count(), "Error en numero de fracciones que cambiaron de nombre y uso de suelo");
            Assert.AreEqual(2, resumenCambios.ObtenerFraccionesQueSiguenIdenticas().Count(), "Error en numero de fracciones que son iguales");
            Assert.AreEqual(0, resumenCambios.FraccionesSidixQueNoTienenContraparte.Count(), "Error en numero de fracciones sidix que no tienen contraparte");
            Assert.AreEqual(1, resumenCambios.FraccionesAutocadQueNoTienenContraparte.Count(), "Error en numero de fracciones autocad que no tienen contraparte");

            Assert.AreEqual(0, resumenCambios.ObtenerVialidadesQueNomasModificaronNombre().Count(), "Error en numero de vialidades que cambiaron de nombre");
            Assert.AreEqual(1, resumenCambios.ObtenerVialidadesQueNomasModificaronTramo().Count(), "Error en numero de vialidades que cambiaron de tramo");
            Assert.AreEqual(0, resumenCambios.ObtenerVialidadesQueModificaronNombreYTramo().Count(), "Error en numero de vialidades que cambiaron de nombre y tramo");
            Assert.AreEqual(0, resumenCambios.ObtenerVialidadesQueSiguenIdenticas().Count(), "Error en numero de vialidades que son iguales");
            Assert.AreEqual(0, resumenCambios.VialidadesSidixQueNoTienenContraparte.Count(), "Error en numero de vialidades sidix que no tienen contraparte");
            Assert.AreEqual(0, resumenCambios.VialidadesAutocadQueNoTienenContraparte.Count(), "Error en numero de vialidades autocad que no tienen contraparte");


        }
    }
}
