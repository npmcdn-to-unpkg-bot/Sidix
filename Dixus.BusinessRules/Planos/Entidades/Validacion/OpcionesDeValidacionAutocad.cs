using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Planos.Entidades
{
    public class OpcionesDeValidacionAutocad
    {
        public OpcionesDeValidacionAutocad()
        {
            // Fijar valores por default
            ValidarSuperficieTotal = true;
            ValidarQuePoligonosSeanValidos = true;
            ValidarQuePoligonosEstenCerrados = true;
            ValidarQueTodasLasGeometriasSeanPoligonos = true;
            ValidarQuePoligonosNoSeSobrepongan = true;
            AreaTotalDelProyectoEnMetros = 0;
            ToleranciaEnM2ParaProyecto = 0;
        }
        
        /// <summary>
        /// Checar que la suma de superficies de fracciones y vialidades de lo mismo que el area total del proyecto, la cual debe ser especificada usando la propiedad "AreaTotalEsperada". Se puede aplicar un margen de error utilizando la propiedad "MargenDeError". Default es true
        /// </summary>
        public bool ValidarSuperficieTotal { get; set; }
       /// <summary>
        /// Area total del proyecto usada para validar que cambios al sistema tienen el area correcta. Default es 0;
        /// </summary>
        public double AreaTotalDelProyectoEnMetros { get; set; }
        /// <summary>
        /// Margen de error en metros cuadrados respecto al area total del proyecto que se la permite al usuario al momento de actualizar la informacion de planos. Default es 0;
        /// </summary>
        public double ToleranciaEnM2ParaProyecto { get; set; }

        /// <summary>
        /// Checar que todos los records de fracciones y vialidades en la base de datos sean poligonos usando la propiedad ".SpatialTypeName". Default es true
        /// </summary>
        public bool ValidarQueTodasLasGeometriasSeanPoligonos { get; set; }
        /// <summary>
        /// Checar que todos los records de fracciones y vialidades sean validos usando la propiedad ".IsValid". No se aplica la funcion "MakeValid()". Default es true
        /// </summary>
        public bool ValidarQuePoligonosSeanValidos { get; set; }
        /// <summary>
        /// Checar que ningun poligono en las tablas de fracciones y vialidades se sobrepongan a otro utilizando la función ".Intersects()". También ayuda a asegurar que ningun poligono se repita. Default es true
        /// </summary>
        public bool ValidarQuePoligonosNoSeSobrepongan { get; set; }
        /// <summary>
        /// Checar que todos los poligonos estén correctamente cerrados. Default es true
        /// </summary>
        public bool ValidarQuePoligonosEstenCerrados { get; set; }
        /// <summary>
        /// Tamaño maximo en metros cuadrados que puede tener una figura/geometria que representa una sobreposicion. Default es 0;
        /// </summary>
        public double TamañoMaximoDeSobreposiciones { get; set; }
        public bool ValidarQueFraccionesNoSeanInmodificables { get; set; }

    }
}
