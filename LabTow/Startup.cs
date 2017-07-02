﻿
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LabTow.Startup))]

namespace LabTow
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.UseCookieAuthentication( new CookieAuthenticationOptions
            //    {
            //        AuthenticationType = "ApplicationCookie",
            //        LoginPath = new PathString("/auth/Login")
            //    }
            //);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Authentication/Login")
            }
            );
        }
    }
}
