using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace NoiseMonitor.Web.Hubs
{
  public class NoiseDataHub : Hub
  {
    public void Send(string message)
    {
      Clients.All.newMessage(message);
    }
  }
}