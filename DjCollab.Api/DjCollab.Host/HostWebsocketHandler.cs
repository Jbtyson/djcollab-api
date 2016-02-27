using Microsoft.Web.WebSockets;

namespace DjCollab.Host
{
    public class HostWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection chatClients = new WebSocketCollection();
        private int userId;

        public HostWebSocketHandler(int userId)
        {
            this.userId = userId;
        }

        public override void OnOpen()
        {
            chatClients.Add(this);
        }

        public override void OnMessage(string message)
        {
            chatClients.Broadcast(userId + ": " + message);
        }
    }
}
