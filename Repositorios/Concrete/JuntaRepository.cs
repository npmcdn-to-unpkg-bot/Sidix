using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;
using Dixus.Entidades.Identity;

namespace Dixus.Repositorios.Concrete
{
    public class JuntaRepository : Repository<JuntaDeConsejo>, IJuntaRepository
    {
        public DixusContext DixusContext { get { return Context as DixusContext; } }
        public JuntaRepository(DixusContext context) : base(context)
        {

        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFecha(DateTime fecha)
        {
            return DixusContext.JuntasDeConsejo.Where(
                junta =>
                    junta.Fecha.Year == fecha.Year &&
                    junta.Fecha.Month == fecha.Month &&
                    junta.Fecha.Day == fecha.Day);
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFecha(int dia, int mes, int año)
        {
            return DixusContext.JuntasDeConsejo.Where(
                junta =>
                    junta.Fecha.Year == año &&
                    junta.Fecha.Month == mes &&
                    junta.Fecha.Day == dia);
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasEntreFechas(DateTime fechainicio, DateTime fechafinal)
        {
            return DixusContext.JuntasDeConsejo.Where(
                 junta =>
                     junta.Fecha.CompareTo(fechainicio) > 0 &&
                     junta.Fecha.CompareTo(fechafinal) < 0);
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoIncluyendoAcuerdos(string textoBuscado)
        {
            return DixusContext.JuntasDeConsejo.Where(
                junta =>
                    junta.Titulo.ToLower().Contains(textoBuscado.ToLower()) ||
                    junta.Acuerdos.Any(acuerdo => acuerdo.Descripcion.ToLower().Contains(textoBuscado.ToLower())));
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoEnTitulo(string textoBuscado)
        {
            return DixusContext.JuntasDeConsejo.Where(
                junta =>
                    junta.Titulo.ToLower().Contains(textoBuscado.ToLower()));
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasMasRecientes(int howmany)
        {
            return DixusContext.JuntasDeConsejo.OrderBy(jun => jun.Fecha).Take(howmany).ToList();
        }


        // JUNTAS DE UN USUARIO EN ESPECIFICO
        public IEnumerable<JuntaDeConsejo> ObtenerJuntasAsistidasPorUsuario(string userid)
        {
            return DixusContext.JuntasDeConsejo
                .Where(junta => junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasMasRecientesAsistidasPorUsuario(string userid, int howmany)
        {
            return DixusContext.JuntasDeConsejo
                .Where(junta =>junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .OrderBy(jun => jun.Fecha)
                .Take(howmany)
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFechaAsistidasPorUsuario(string userid, DateTime fecha)
        {
            return DixusContext.JuntasDeConsejo
                .Where( junta =>
                        junta.Fecha.Year == fecha.Year &&
                        junta.Fecha.Month == fecha.Month &&
                        junta.Fecha.Day == fecha.Day &&
                        junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasDeFechaAsistidasPorUsuario(string userid, int dia, int mes, int año)
        {
            return DixusContext.JuntasDeConsejo
                .Where( junta =>
                        junta.Fecha.Year == año &&
                        junta.Fecha.Month == mes &&
                        junta.Fecha.Day == dia &&
                        junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasEntreFechasAsistidasPorUsuario(string userid, DateTime fechainicio, DateTime fechafinal)
        {
            return DixusContext.JuntasDeConsejo
                .Where( junta =>
                        junta.Fecha.CompareTo(fechainicio) > 0 &&
                        junta.Fecha.CompareTo(fechafinal) < 0 &&
                        junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoIncluyendoAcuerdosAsistidasPorUsuario(string userid, string textoBuscado)
        {
            return DixusContext.JuntasDeConsejo
                .Where( junta =>
                        junta.Titulo.ToLower().Contains(textoBuscado.ToLower()) ||
                        junta.Acuerdos.Any(acuerdo => acuerdo.Descripcion.ToLower().Contains(textoBuscado.ToLower())) &&
                        junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }

        public IEnumerable<JuntaDeConsejo> ObtenerJuntasQueIncluyanTextoEnTituloAsistidasPorUsuario(string userid, string textoBuscado)
        {
            return DixusContext.JuntasDeConsejo
                .Where( junta =>
                        junta.Titulo.ToLower().Contains(textoBuscado.ToLower()) &&
                        junta.UsuariosPresentes.Any(usuario => usuario.Id == userid))
                .ToList();
        }
    }
}
