using Dixus.Entidades;
using Dixus.Entidades.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.Fracciones.Abstract
{
    public interface IFraccionFactory
    {
        Fraccion ConvertirFraccionAOtroUsoDeSuelo(Fraccion fraccionVieja, int nuevoUsoDeSueloId);
        Fraccion CrearFraccionAPartirDeTerrenoAutocad(FeatureFraccion fraccionAutocad);
    }
}
