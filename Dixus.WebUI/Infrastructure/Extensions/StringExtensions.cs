using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixus.WebUI.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string PrimeraLetraMayuscula(this string texto)
        {
            char[] c = texto.ToCharArray();
            c[0] = char.ToUpper(c[0]);
            return new string(c);
        }
    }
}