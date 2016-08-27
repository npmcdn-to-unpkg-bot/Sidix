using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dixus.WebUI.Infrastructure;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Dixus.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            filters.Add(new LoginInfoAttribute());
        }

    }
}