using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.SignalR;
using NoiseMonitor.Web.Hubs;

namespace NoiseMonitor.Web.Controllers
{
  public class NoiseDataController : ApiController
  {
    public IHttpActionResult Post(NoiseEvent noiseEvent)
    {

      Debug.Write(noiseEvent.DateTime);
      var context = GlobalHost.ConnectionManager.GetHubContext<NoiseDataHub>();

      context.Clients.All.newMessage(noiseEvent.Level);

      return Ok();
    }

  }

  public class NoiseEvent
  {
    public DateTime DateTime { get; set; }
    public double Level { get; set; }
  }
}