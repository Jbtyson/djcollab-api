using System.Collections.Generic;
using DjCollab.Party.Data;

namespace DjCollab.Party
{
    public class PartyService : IPartyService
    {
        public Model.Party AddSongToParty(int partyId, int songId)
        {
            var party = FakePartyDb.GetParty(partyId);
            party.SongList.Add(songId);
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
