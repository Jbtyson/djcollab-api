using System.Collections.Generic;

namespace DjCollab.Host
{
    public interface IHostService
    {
        IList<HostWebSocketHandler> GetHosts();
        HostWebSocketHandler GetHostByPartyId(int partyId); 
        void CreateHostWebSocketHandler(int userId);
        void SendMessage(int hostId, string message);
        void AddHost(HostWebSocketHandler hostWebSocketHandler);
        void OnDisconnect(int id);
    }
}
