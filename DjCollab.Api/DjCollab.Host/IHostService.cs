namespace DjCollab.Host
{
    public interface IHostService
    {
        void CreateHostWebSocketHandler(int userId);
        void SendMessage(int hostId, string message);
        void AddHost(HostWebSocketHandler hostWebSocketHandler);
    }
}
