using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dixus.Entidades
{
    //[Table("NoVendibles")]
    public abstract class FraccionNoVendibles : Fraccion
    {
        public override double GetLpsMedioDiarioAgua()
        {
            return 0;
        }

    }

    
}