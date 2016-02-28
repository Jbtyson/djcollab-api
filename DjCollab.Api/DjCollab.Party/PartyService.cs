using System.Collections.Generic;
using DjCollab.Host;
using DjCollab.Party.Data;

namespace DjCollab.Party
{
    public class PartyService : IPartyService
    {
        private readonly IHostService hostService;

        public PartyService()
        {
            hostService = new HostService();
        }

        public PartyService(IHostService hostService)
        {
            this.hostService = hostService;
        }

        public Model.Party AddSongToParty(int senderId, int partyId, int songId)
        {
            var party = FakePartyDb.GetParty(partyId);
            party.SongList.Add(songId);
            hostService.SendMessage(party.HostId, senderId, $"add:{songId}");
            return party;
        }

        public Model.Party GetParty(int partyId)
        {
            return FakePartyDb.GetParty(partyId);
        }

        public Model.Party CreateParty(int userId, Model.Party party)
        {
            party.HostId = userId;
            return FakePartyDb.CreateParty(party);
        }
    }
}
