using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.BusinessRules.CambiosAutocad.Abstract
{
    public interface ITransformadorDeGeometriaAGeoJson
    {
        object[] ConvertirPoligonoEnCoordinadasGeoJson(DbGeometry geometria);
    }

    
}
