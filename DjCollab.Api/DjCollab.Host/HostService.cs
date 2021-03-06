﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.WebSockets;

namespace DjCollab.Host
{
    public class HostService : IHostService
    {
        private static readonly Dictionary<int, HostWebSocketHandler> hostWebSocketHandlers = new Dictionary<int, HostWebSocketHandler>();
        private static int idCount = 0;

        public HostService()
        {
        }

        public HostService(IDictionary<int, HostWebSocketHandler> hostWebSocketHandlers)
        {
            foreach (KeyValuePair<int, HostWebSocketHandler> kvp in hostWebSocketHandlers)
            {
                HostService.hostWebSocketHandlers[kvp.Key] = kvp.Value;
            }
        }

        public IList<int> GetHosts()
        {
            return hostWebSocketHandlers.Keys.ToList();
        }

        public void CreateHostWebSocketHandler(int userId)
        {
        }

        public void SendMessage(int hostId, string message)
        {
            hostWebSocketHandlers[hostId].Send(message);
        }

        public void AddHost(HostWebSocketHandler hostWebSocketHandler)
        {
            var id = idCount++;
            hostWebSocketHandler.HostId = id;
            hostWebSocketHandlers[id] = hostWebSocketHandler;
            hostWebSocketHandler.Send($"id:{id}");
        }

        public void Register(int hostId, int partyId)
        {
            hostWebSocketHandlers[hostId].PartyId = partyId;
        }

        public void OnDisconnect(int id)
        {
            hostWebSocketHandlers.Remove(id);
        }

        public HostWebSocketHandler GetHostByPartyId(int partyId)
        {
            var results = hostWebSocketHandlers.Values.Where(h => h.PartyId == partyId);
            if (results.Any())
            {
                return results.First();
            }
            throw new KeyNotFoundException($"No party found for id: {partyId}");
        }
    }
}