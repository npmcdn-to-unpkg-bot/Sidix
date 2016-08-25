using AutoMapper;
using Dixus.Entidades;
using Dixus.Entidades.Identity;
using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Dixus.WebUI.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using Dixus.BusinessRules.Planos.Entidades;
#pragma warning disable CS0618 // Type or member is obsolete

namespace Dixus.WebUI
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            ConfigurarMapasFracciones();
            ConfigurarMapasUsuarios();
            ConfigurarMapasOpciones();
        }

        private static void ConfigurarMapasOpciones()
        {
            Mapper.CreateMap<Opciones, AdminOpcionesViewModel>();
            Mapper.CreateMap<AdminOpcionesViewModel, Opciones>();
            Mapper.CreateMap<Opciones, OpcionesDeValidacionAutocad>();
        }

        private static void ConfigurarMapasUsuarios()
        {
            Mapper.CreateMap<MyUser, UsuariosConRol>()
                .ForMember(dest => dest.Roles, opt => new List<string>());
        }

        public static void ConfigurarMapasFracciones()
        {
            Mapper.CreateMap<CrearFraccionViewModel, FraccionViviendaEconomica>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionViviendaSocial>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionViviendaMedia>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionViviendaPopular>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionViviendaResidencial>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionCOM>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionCS>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionIN>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionPAT>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionSE>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionAC>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionRE>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionEU>();
            Mapper.CreateMap<CrearFraccionViewModel, FraccionDON>();
            //Mapper.CreateMap<CrearFraccionViewModel, FraccionVIAL>();
        }

    }
}
