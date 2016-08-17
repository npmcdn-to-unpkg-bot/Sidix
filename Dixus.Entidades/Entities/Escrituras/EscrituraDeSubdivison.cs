using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    [Table("EscriturasSubdivision"/*, Schema = "Legal"*/)]
    public class EscrituraDeSubdivision : Escritura
    {
        public int NumDeSubdivision { get; set; }

        public virtual ICollection<FraccionLegal> Subdivisiones { get; set; }

    }
}
