using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("Vendibles")]
    public abstract class FraccionVendible : Fraccion, IValidatableObject
    {
        public int? AñoDeVentaPronosticado { get; set; }

        public int? GetAñoDeVenta()
        {
            if ( SubdivisionLegal == null)
            {
                // Si no tiene referencia a una subdivision legal, significa que esta libre y por lo tanto agarra el año de venta pronosticado, en caso de haber uno
                return AñoDeVentaPronosticado.HasValue ? AñoDeVentaPronosticado.Value : (int?)null;
            }
            else
            {
                // Si esta libre, comprometida, o en garantía, agarrar el año de venta pronosticado, en caso de haber uno
                if (SubdivisionLegal.Estatus == EstatusDeSubdivision.Libre ||
                    SubdivisionLegal.Estatus == EstatusDeSubdivision.Comprometida ||
                    SubdivisionLegal.Estatus == EstatusDeSubdivision.Garantia) return AñoDeVentaPronosticado.HasValue ? AñoDeVentaPronosticado.Value : (int?)null;
                
                // Si está donada, regresar null porque nunca se va a vender
                if ( SubdivisionLegal.Estatus == EstatusDeSubdivision.Donada ) return null;

                // Si está vendida, agarrar el año de traspaso de la escritura de compraventa
                if (SubdivisionLegal.Estatus == EstatusDeSubdivision.Vendida && 
                    SubdivisionLegal.EscrituraDeTraspaso != null) return SubdivisionLegal.EscrituraDeTraspaso.FechaDeTraspaso.Year;

                return null;
            }
        }




    }

}