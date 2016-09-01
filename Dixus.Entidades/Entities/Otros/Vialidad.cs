using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixus.Entidades
{
    [Table("Vialidades")]
    public class Vialidad : Entidad
    {
        [Key]
        public int VialidadId { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tramo { get; set; }
        public double MetrosCuadrados { get; set; }
        public double Hectareas => MetrosCuadrados / 10000;
        public double? FactorTopografico { get; set; }
        [Required]
        public DbGeometry Geometria { get; set; }

        //Metodos
        public virtual double GetMvaRequeridos()
        {
            return 0;
        }
        public virtual double GetLpsMedioDiarioAgua()
        {
            return 0;
        }
        public virtual double GetLpsMedioDiarioSaneamiento()
        {
            return GetLpsMedioDiarioAgua() * 0.75;
        }

        public int? NumeroDeCarriles { get; set; }
        public double? Longitud { get; set; }
    }
}
