﻿using System;
using System.Collections.Generic;
using Dixus.Domain;
using Dixus.Entidades;
using Dixus.Repositorios.Abstract;
using System.Linq;

namespace Dixus.Repositorios.Concrete
{
    public class TipoDeInversionRepository : Repository<TipoInversion>, ITipoDeInversionRepository
    {
        public TipoDeInversionRepository(DixusContext context) : base(context)
        {

        }

    }
}
