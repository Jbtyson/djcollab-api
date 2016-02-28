using System;
using System.Collections.Generic;
using System.IO;
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

        public Model.Party DeleteSongFromParty(int partyId, string songId)
        {
            return FakePartyDb.DeleteSongFromParty(partyId, songId);
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
            var party = new Model.Party()
            {
                Name = name,
                HostId = -1,
                SongList = new List<string>()
            };
            return FakePartyDb.CreateParty(party);
        }
    }
}
