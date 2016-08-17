using Dixus.Entidades;
using Dixus.Entidades.Identity;
using System;
using System.Collections.Generic;

namespace Dixus.Repositorios.Abstract
{
    public interface IJuntaRepository : IRepository<JuntaDeConsejo>
    {

        IEnumerable<JuntaDeConsejo> ObtenerJuntasAsistidasPorUsuario(string userid);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasMasRecientesAsistidasPorUsuario(string userid, int howmany);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFechaAsistidasPorUsuario(string userid, DateTime fecha);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFechaAsistidasPorUsuario(string userid, int dia, int mes, int año);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasEntreFechasAsistidasPorUsuario(string userid, DateTime fechainicio, DateTime fechafinal);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoIncluyendoAcuerdosAsistidasPorUsuario(string userid, string textoBuscado);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoEnTituloAsistidasPorUsuario(string userid, string textoBuscado);

        IEnumerable<JuntaDeConsejo> ObtenerJuntasMasRecientes(int howmany);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFecha(DateTime fecha);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFecha(int dia, int mes, int año);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasEntreFechas(DateTime fechainicio, DateTime fechafinal);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoIncluyendoAcuerdos(string textoBuscado);
        IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoEnTitulo(string textoBuscado);

    }
}
