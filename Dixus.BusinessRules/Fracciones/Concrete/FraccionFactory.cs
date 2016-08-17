using Dixus.BusinessRules.Fracciones.Abstract;
using System;
using Dixus.Entidades;
using AutoMapper;
using Dixus.Entidades.Gis;
using System.Data.Entity.Spatial;
#pragma warning disable CS0618 // Type or member is obsolete

namespace Dixus.BusinessRules.Fracciones.Concrete
{
    public class FraccionFactory : IFraccionFactory
    {
        public Fraccion ConvertirFraccionAOtroUsoDeSuelo(Fraccion fraccionVieja, int nuevoUsoDeSueloId)
        {
            switch (nuevoUsoDeSueloId)
            {
                case (int)TiposDeSuelo.ViviendaEconomica:
                    return Mapper.DynamicMap<FraccionViviendaEconomica>(fraccionVieja);

                case (int)TiposDeSuelo.ViviendaSocial:
                    return Mapper.DynamicMap<FraccionViviendaSocial>(fraccionVieja);

                case (int)TiposDeSuelo.ViviendaPopular:
                    return Mapper.DynamicMap<FraccionViviendaPopular>(fraccionVieja);

                case (int)TiposDeSuelo.ViviendaMedia:
                    return Mapper.DynamicMap<FraccionViviendaMedia>(fraccionVieja);

                case (int)TiposDeSuelo.ViviendaResidencial:
                    return Mapper.DynamicMap<FraccionViviendaResidencial>(fraccionVieja);

                case (int)TiposDeSuelo.Comercial:
                    return Mapper.DynamicMap<FraccionCOM>(fraccionVieja);

                case (int)TiposDeSuelo.ComercioYServicios:
                    return Mapper.DynamicMap<FraccionCS>(fraccionVieja);

                case (int)TiposDeSuelo.Industrial:
                    return Mapper.DynamicMap<FraccionIN>(fraccionVieja);

                case (int)TiposDeSuelo.ParqueAltaTecnologia:
                    return Mapper.DynamicMap<FraccionPAT>(fraccionVieja);

                case (int)TiposDeSuelo.ServiciosEspeciales:
                    return Mapper.DynamicMap<FraccionSE>(fraccionVieja);

                case (int)TiposDeSuelo.AreaConservacion:
                    return Mapper.DynamicMap<FraccionAC>(fraccionVieja);

                case (int)TiposDeSuelo.ReservaEstrategica:
                    return Mapper.DynamicMap<FraccionRE>(fraccionVieja);

                case (int)TiposDeSuelo.EquipamentoUrbano:
                    return Mapper.DynamicMap<FraccionEU>(fraccionVieja);

                case (int)TiposDeSuelo.Donaciones:
                    return Mapper.DynamicMap<FraccionDON>(fraccionVieja);

                default:
                    throw new ArgumentException("El ID del tipo de suelo proporcionado no corresponde a ningún ID válido");
            }
        }

        public Fraccion CrearFraccionAPartirDeTerrenoAutocad(FeatureFraccion fraccionAutocad)
        {
            FeatureFraccion fa = fraccionAutocad;
            Fraccion nuevaSidix = CrearFraccionConInfoBasica(fa.Nombre, fa.ObtenerUsoDeSueloId(), fa.Geometry);

            nuevaSidix.Zona = fa.Zona;
            nuevaSidix.Manzana = fa.Manzana;
            nuevaSidix.Lote = fa.Lote;
            nuevaSidix.Etapa = fa.ObtenerEtapaEnNumero();
            nuevaSidix.FactorTopografico = fa.FactorTopo;

            return nuevaSidix;
        }

        private Fraccion CrearFraccionConInfoBasica(string nombre, int usoDeSueloId, DbGeometry geometria)
        {
            Fraccion nuevaFraccion;
            switch (usoDeSueloId)
            {
                case (int)TiposDeSuelo.ViviendaEconomica:
                    nuevaFraccion = new FraccionViviendaEconomica() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ViviendaSocial:
                    nuevaFraccion = new FraccionViviendaSocial() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ViviendaPopular:
                    nuevaFraccion = new FraccionViviendaPopular() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ViviendaMedia:
                    nuevaFraccion = new FraccionViviendaMedia() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ViviendaResidencial:
                    nuevaFraccion = new FraccionViviendaResidencial() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.Comercial:
                    nuevaFraccion = new FraccionCOM() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ComercioYServicios:
                    nuevaFraccion = new FraccionCS() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.Industrial:
                    nuevaFraccion = new FraccionIN() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ParqueAltaTecnologia:
                    nuevaFraccion = new FraccionPAT() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ServiciosEspeciales:
                    nuevaFraccion = new FraccionSE() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.AreaConservacion:
                    nuevaFraccion = new FraccionAC() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.ReservaEstrategica:
                    nuevaFraccion = new FraccionRE() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.EquipamentoUrbano:
                    nuevaFraccion = new FraccionEU() { Nombre = nombre, Geometria = geometria }; break;

                case (int)TiposDeSuelo.Donaciones:
                    nuevaFraccion = new FraccionDON() { Nombre = nombre, Geometria = geometria }; break;

                default:
                    throw new ArgumentException("El ID del tipo de suelo proporcionado no corresponde a ningún ID válido");
            }
            return nuevaFraccion;
        }
    }
}
