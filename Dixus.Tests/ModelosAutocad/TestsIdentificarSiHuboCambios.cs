using Dixus.BusinessRules.Planos.Abstract;
using Dixus.BusinessRules.Planos.Concrete;
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
    public class TestsIdentificarSiHuboCambios
    {
       
        [TestMethod]
        public void Identifica_Que_Sets_Son_Iguales()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { Nombre = "F2", TipoDeSueloId = 2, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FraccionCOM { Nombre = "F3", TipoDeSueloId = 3, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "F1", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FeatureFraccion { Nombre = "F3", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-2", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            bool haCambiado = detector.ChecarSiModeloHaCambiado();

            // Assert
            Assert.IsFalse(haCambiado);
        }

        [TestMethod]
        public void Identifica_Un_Cambio_De_Uso_De_Suelo()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { Nombre = "F2", TipoDeSueloId = 10 /*CAMBIO AQUI*/, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FraccionCOM { Nombre = "F3", TipoDeSueloId = 3, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "F1", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FeatureFraccion { Nombre = "F3", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-2", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            bool haCambiado = detector.ChecarSiModeloHaCambiado();

            // Assert
            Assert.IsTrue(haCambiado);
        }

        [TestMethod]
        public void Identifica_Un_Cambio_De_Nombre_De_Fraccion()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { Nombre = "F2", TipoDeSueloId = 2, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FraccionCOM { Nombre = "F100" /*CAMBIO AQUI*/, TipoDeSueloId = 3, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "F1", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FeatureFraccion { Nombre = "F3", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-2", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            bool haCambiado = detector.ChecarSiModeloHaCambiado();

            // Assert
            Assert.IsTrue(haCambiado);
        }

        [TestMethod]
        public void Identifica_Un_Cambio_De_Geometria_Fraccion()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 39 40, 20 40, 10 20, 30 10))" /*CAMBIO AQUI 40-39*/,0) },
                new FraccionCOM { Nombre = "F2", TipoDeSueloId = 2, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FraccionCOM { Nombre = "F3", TipoDeSueloId = 3, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "F1", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
                new FeatureFraccion { Nombre = "F3", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) }
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-2", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            bool haCambiado = detector.ChecarSiModeloHaCambiado();

            // Assert
            Assert.IsTrue(haCambiado);
        }

        [TestMethod]
        public void Identifica_Que_Sets_Son_Iguales_Con_Cambio_De_Orden()
        {
            // Arrange
            var fraccionesSidix = new Fraccion[]
            {
                new FraccionCOM { Nombre = "F1", TipoDeSueloId = 1, Geometria = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FraccionCOM { Nombre = "F3", TipoDeSueloId = 3, Geometria = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) },
                new FraccionCOM { Nombre = "F2", TipoDeSueloId = 2, Geometria = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
            };

            var fraccionesAutocad = new FeatureFraccion[]
            {
                new FeatureFraccion { Nombre = "F3", Uso = "VP", Geometry = DbGeometry.PolygonFromText("POLYGON ((10 50, 40 40, 20 40, 10 20, 10 50))",0) },
                new FeatureFraccion { Nombre = "F1", Uso = "VE", Geometry = DbGeometry.PolygonFromText("POLYGON ((30 10, 40 40, 20 40, 10 20, 30 10))",0) },
                new FeatureFraccion { Nombre = "F2", Uso = "VS", Geometry = DbGeometry.PolygonFromText("POLYGON ((35 10, 40 40, 20 40, 10 20, 35 10))",0) },
            };

            var vialidadesSidix = new Vialidad[]{
                new Vialidad {VialidadId = 1, Nombre = "V1", Tramo = "Tramo-2", Geometria = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            var vialidadesAutocad = new VialPoly[]
            {
                new VialPoly { ViaNombre = "V1", ViaTramo = "Tramo-2", Geom = DbGeometry.FromText("POLYGON ((10 10, 40 10, 40 40, 10 40, 10 10))",0) }
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            bool haCambiado = detector.ChecarSiModeloHaCambiado();

            // Assert
            Assert.IsFalse(haCambiado);
        }


    }
}
