using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Web.WebSockets;

namespace DjCollab.Host
{
    public class HostWebSocketHandler : WebSocketHandler
    {
        private static IHostService hostService = new HostService();
        public int HostId { get; set; }
        public int PartyId { get; set; }

        public HostWebSocketHandler(int partyId)
        {
            PartyId = partyId;
        }

        public override void OnOpen()
        {
            hostService.AddHost(this);
        }

        public override void OnMessage(string message)
        {
        }

        public override void OnClose()
        {
            base.OnClose();
            hostService.OnDisconnect(HostId);
        }
    }
}
