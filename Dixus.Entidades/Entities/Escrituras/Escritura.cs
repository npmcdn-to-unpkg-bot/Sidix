using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dixus.Entidades
{
    public abstract class Escritura : Entidad
    {
        [Key]
        public int EscrituraId { get; set; }
        public byte[] Pdf { get; set; }

    }



  


}
