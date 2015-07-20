using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NoiseMonitor.Web.Startup))]

namespace NoiseMonitor.Web
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.MapSignalR();
      ConfigureAuth(app);
    }
  }
}
