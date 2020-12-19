using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BodyGenic.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello(DateTime.Now);
        }
        public void Send(string name, string message) 
        {
            Clients.All.sendMessageToAllClients(name, message, DateTime.Now);
        }
    }
}