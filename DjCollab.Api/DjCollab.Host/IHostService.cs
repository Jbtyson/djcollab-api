namespace DjCollab.Host
{
    public interface IHostService
    {
        void CreateHostWebSocketHandler(int userId);
        void SendMessage(int hostId, int senderId, string message);
        void AddHost(HostWebSocketHandler hostWebSocketHandler);
    }
}
