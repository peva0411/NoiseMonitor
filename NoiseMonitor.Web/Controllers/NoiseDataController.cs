using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Globalization;
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

      var date = DateTime.ParseExact(noiseEvent.DateTime, @"ddd MMM dd HH:mm:ss UTC yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

      var dateLocal = date.ToLocalTime();

      noiseEvent.DateTime = dateLocal.ToString();

      context.Clients.All.newMessage(noiseEvent);

      return Ok();
    }

  }

  public class NoiseEvent
  {
    public string DateTime { get; set; }
    public double Level { get; set; }
  }
}