using System.Collections.Generic;

namespace DjCollab.Host
{
    public interface IHostService
    {
        IList<int> GetHosts();
        HostWebSocketHandler GetHostByPartyId(int partyId); 
        void CreateHostWebSocketHandler(int userId);
        void SendMessage(int hostId, string message);
        void AddHost(HostWebSocketHandler hostWebSocketHandler);
        void Register(int hostId, int partyId);
        void OnDisconnect(int id);
    }
}
