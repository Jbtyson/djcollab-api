using System.Collections.Generic;
using Microsoft.Web.WebSockets;

namespace DjCollab.Host
{
    public class HostService : IHostService
    {
        private static readonly WebSocketCollection webSocketCollection = new WebSocketCollection();
        private static readonly Dictionary<int, HostWebSocketHandler> hostWebSocketHandlers = new Dictionary<int, HostWebSocketHandler>();

        public void CreateHostWebSocketHandler(int userId)
        {
        }

        public void SendMessage(int hostId, int senderId, string message)
        {
            hostWebSocketHandlers[hostId].Send(message);
        }

        public void AddHost(int hostId, HostWebSocketHandler hostWebSocketHandler)
        {
            webSocketCollection.Add(hostWebSocketHandler);
            hostWebSocketHandlers[hostId] = hostWebSocketHandler;
        }
    }
}