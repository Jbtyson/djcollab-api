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

        public Model.Party AddSongToParty(int partyId, string songId)
        {
            var party = FakePartyDb.GetParty(partyId);
            party.SongList.Add(songId);
            hostService.SendMessage(party.HostId, $"add:{songId}");
            return party;
        }

        public Model.Party GetParty(int partyId)
        {
            return FakePartyDb.GetParty(partyId);
        }

        public IList<Model.Party> GetAllParties()
        {
            return FakePartyDb.GetAllParties();
        } 

        public Model.Party CreateParty(string name)
        {
            var party = new Model.Party();
            party.Name = name;
            return FakePartyDb.CreateParty(party);
        }
    }
}
