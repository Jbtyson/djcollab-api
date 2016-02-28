using System.Net;
using Microsoft.Web.WebSockets;

namespace DjCollab.Host
{
    public class HostWebSocketHandler : WebSocketHandler
    {
        private static IHostService hostService = new HostService();

        public HostWebSocketHandler()
        {
        }

        public override void OnOpen()
        {
            hostService.AddHost(this);
        }

        public override void OnMessage(string message)
        {
            var param = message.Split('/');
            //hostService.SendMessage(int.Parse(param[0]), int.Parse(param[1]), param[2]);
        }
    }
}
