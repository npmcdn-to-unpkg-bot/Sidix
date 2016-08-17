using System.Collections.Generic;
using Dixus.Entidades;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Dixus.Repositorios.Abstract
{
    public interface IFraccionRepository : IRepository<Fraccion>
    {
        // OBTENER FRACCIONES
        Task<IEnumerable<Fraccion>> ObtenerComoEstabanEnFecha(DateTime fecha);
        Task<IEnumerable<Fraccion>> ObtenerPorEtapa(int etapa);
        Task<IEnumerable<Fraccion>> ObtenerMasGastadorasDeEnergia(int howmany);
        Task<IEnumerable<Fraccion>> ObtenerMasGastadorasDeAgua(int howmany);
        Task<IEnumerable<Fraccion>> ObtenerMasGrandes(int howmany);
        Task<IEnumerable<Fraccion>> ObtenerMasChicas(int howmany);
        Task<IEnumerable<Fraccion>> ObtenerDonadas();
        Task<IEnumerable<Fraccion>> ObtenerEnGarantia();
        Task<IEnumerable<Fraccion>> ObtenerComprometidas();
        Task<IEnumerable<Fraccion>> ObtenerLibres();
        Task<IEnumerable<Fraccion>> ObtenerPorCliente(int clienteid);
        Task<IEnumerable<FraccionVendible>> ObtenerPorVender();
        Task<IEnumerable<FraccionVendible>> ObtenerVendidas();
        Task<IEnumerable<FraccionVendible>> ObtenerPorAñoDeVenta(int año);
        Task<IEnumerable<FraccionVendible>> ObtenerEnRangoDeAños(int añoinicio, int añofinal);

        // AREAS
        Task<double> AreaTotal();
        Task<double> AreaPorEtapa(int etapa);
        Task<double> AreaPorTipoDeSuelo(int tipodesueloId);
        Task<double> AreaConsideradaEnInversiones();
        Task<double> AreaExlcuidaDeInversiones();
        Task<double> AreaPorCliente(int clienteid);
        // VIVIENDA
        Task<int> NumeroDeViviendasDesarrolladas();
        Task<int> NumeroDeViviendasEnProceso();
        Task<int> NumeroDeViviendasPorDesarrollar();
        Task<int> NumeroDeViviendasTotales();
        

    // GENERICOS

        // OBTENER FRACCIONES GENERICOS
        Task<IEnumerable<TFraccion>> Obtener<TFraccion>() where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerComoEstabanEnFecha<TFraccion>(DateTime fecha) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerPorEtapa<TFraccion>(int etapa) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerMasGastadorasDeEnergia<TFraccion>(int howmany) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerMasGastadorasDeAgua<TFraccion>(int howmany) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerMasGrandes<TFraccion>(int howmany) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerMasChicas<TFraccion>(int howmany) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerDonadas<TFraccion>() where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerEnGarantia<TFraccion>() where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerComprometidas<TFraccion>() where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerLibres<TFraccion>() where TFraccion : Fraccion;
        Task<IEnumerable<TFraccion>> ObtenerPorCliente<TFraccion>(int clienteid) where TFraccion : Fraccion;
        Task<IEnumerable<TFraccionVendible>> ObtenerPorVender<TFraccionVendible>() where TFraccionVendible : FraccionVendible;
        Task<IEnumerable<TFraccionVendible>> ObtenerVendidas<TFraccionVendible>() where TFraccionVendible : FraccionVendible;
        Task<IEnumerable<TFraccionVendible>> ObtenerPorAñoDeVenta<TFraccionVendible>(int año) where TFraccionVendible : FraccionVendible;
        Task<IEnumerable<TFraccionVendible>> ObtenerEnRangoDeAños<TFraccionVendible>(int añoinicio, int añofinal) where TFraccionVendible : FraccionVendible;
        // CALCULAR AREAS GENERICOS
        Task<double> AreaTotal<TFraccion>() where TFraccion : Fraccion;
        Task<double> AreaPorEtapa<TFraccion>(int etapa) where TFraccion : Fraccion;
        Task<double> AreaPorCliente<TFraccion>(int clienteid) where TFraccion : FraccionVivienda;
        // VIVIENDA GENERICOS
        Task<int> NumeroDeViviendasDesarrolladas<TFraccion>() where TFraccion : FraccionVivienda;
        Task<int> NumeroDeViviendasEnProceso<TFraccion>() where TFraccion : FraccionVivienda;
        Task<int> NumeroDeViviendasPorDesarrollar<TFraccion>() where TFraccion : FraccionVivienda;
        Task<int> NumeroDeViviendasTotales<TFraccion>() where TFraccion : FraccionVivienda;
    }
}
