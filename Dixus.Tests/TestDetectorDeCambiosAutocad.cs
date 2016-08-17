using Dixus.BusinessRules.CambiosAutocad.Abstract;
using Dixus.BusinessRules.CambiosAutocad.Concrete;
using Dixus.BusinessRules.CambiosAutocad.Entidades;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Entidades.Gis;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Spatial;
using System.Diagnostics;
using System.Linq;

namespace Dixus.Tests
{
    [TestClass]
    public class TestDetectorDeCambiosAutocad
    {
        

        [TestMethod]
        public void Puede_Correr_Validacion_En_Base_De_Datos()
        {
            // Arrange
            IUnitOfWork uow = new UnitOfWork(new DixusContext());
            var fraccionesSidix = uow.Fracciones.Obtener();
            var fraccionesAutocad = uow.Gis.ObtenerFracciones();
            var vialidadesSidix = uow.Vialidades.Obtener();
            var vialidadesAutocad = uow.Gis.ObtenerPoligonosVialidades();
            
            var opciones = new OpcionesDeValidacionAutocad()
            {
                ToleranciaEnM2ParaProyecto = 10327709,
                //Demas opciones en blanco -> validar todo
            };

            // Act
            IDetectorDeCambiosAutocad detector = new DetectorDeCambiosAutocad(fraccionesSidix, fraccionesAutocad, vialidadesSidix, vialidadesAutocad);
            //var validacion = detector.ChecarSiModeloAutocadEsValido(opciones).Result;
          
            // Assert
            //Assert.IsTrue(validacion);
        }

        
    }
    
}
