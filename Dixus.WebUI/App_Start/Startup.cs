using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;
using System.Threading.Tasks;
using System.IO;

namespace Dixus.WebUI
{
   
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookie",
                LoginPath = new Microsoft.Owin.PathString("/Login")
            });

        }

    }
}