using System.Collections.Generic;

namespace DjCollab.Host
{
    public interface IHostService
    {
        IList<int> GetHosts(); 
        void CreateHostWebSocketHandler(int userId);
        void SendMessage(int hostId, string message);
        void AddHost(HostWebSocketHandler hostWebSocketHandler);
    }
}
