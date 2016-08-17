using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dixus.BusinessRules.Inversiones.Entidades;

namespace Dixus.WebUI.Models
{
    public class InversionesIndexModel
    {
        public ConcentradoDeInversiones TotalesDeInversiones { get; set; }
        public CobrosPorInversiones PreciosUnitariosPorTipoDeInversion { get; set; }
    }

    public class ConcentradoDeInversiones
    {
        public decimal InversionEnEnergia { get; set; }
        public decimal InversionEnAguaPotable { get; set; }
        public decimal InversionEnSaneamiento { get; set; }
        public decimal InversionEnVialidades { get; set; }
        public decimal InversionEnRedDigital { get; set; }
        public decimal InversionEnGasNatural { get; set; }
        public decimal InversionEnMovimientoDeTierra { get; set; }
        public decimal InversionEnObrasEspeciales { get; set; }

        public decimal TotalInversionesEnInfraestructura
        {
            get
            {
                decimal result = 0;
                result += InversionEnEnergia;
                result += InversionEnAguaPotable;
                result += InversionEnSaneamiento;
                result += InversionEnVialidades;
                result += InversionEnRedDigital;
                result += InversionEnGasNatural;
                result += InversionEnMovimientoDeTierra;
                result += InversionEnObrasEspeciales;
                return result;
            }
        }

        public decimal InversionEnEstudiosYProyectos { get; set; }
        public decimal InversionEnPostVenta { get; set; }
        public decimal InversionEnCostosIndirectosDeObra { get; set; }

        public decimal TotalInversionesEnAdministracion
        {
            get
            {
                return InversionEnEstudiosYProyectos + InversionEnPostVenta + InversionEnCostosIndirectosDeObra;
            }
        }

        public decimal TotalInversiones => TotalInversionesEnInfraestructura + TotalInversionesEnAdministracion;
    }

    public class EnergiaElectricaViewModel
    {
        public double TotalDeMvasDisponibles { get; set; }

        public double MVasPorViviendaEconomica { get; set; }
        public double MVasPorViviendaSocial { get; set; }
        public double MVasPorViviendaResidencial { get; set; }
        public double MVasPorViviendaPopular { get; set; }
        public double MVasPorViviendaMedia { get; set; }
        public double MVasPorComerciales { get; set; }
        public double MVasPorComercioYServicios { get; set; }
        public double MVasPorIndustrial { get; set; }
        public double MVasPorServiciosEspeciales { get; set; }
        public double MVasPorVialidades { get; set; }
        public double MVasPorDonaciones { get; set; }
        public double MVasPorEquipamiento { get; set; }
        public double MVasPorParqueTecnologico { get; set; }
        public double MVasPorAreasDeConservacion { get; set; }
        public double MVasPorReservaEstrategica { get; set; }

        public double TOtalDeMvasUsados { get; set; }

    }

}