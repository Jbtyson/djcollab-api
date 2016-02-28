using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DjCollab.Party.Data
{
    public static class FakePartyDb
    {
        private static IList<Model.Party> parties = new List<Model.Party>();
        private static int nextId;

        public static Model.Party CreateParty(Model.Party party)
        {
            party.Id = nextId++;
            parties.Add(party);
            return GetParty(party.Id);
        }

        public static Model.Party GetParty(int partyId)
        {
            foreach (var p in parties)
            {
                if (p.Id == partyId)
                {
                    return p;
                }
            }
            throw new KeyNotFoundException(); ;
        }

        public static void UpdatePartyHost(int partyId, int hostId)
        {
            foreach (var p in parties)
            {
                if (p.Id == partyId)
                    p.HostId = hostId;
            }
        }

        public static IList<Model.Party> GetAllParties()
        {
            return parties;
        } 

        public static void Reset()
        {
            parties.Clear();
            nextId = 0;
        }

        public static Model.Party DeleteSongFromParty(int partyId, string songId)
        {
            foreach (var p in parties)
            {
                if (p.Id == partyId)
                {
                    p.SongList.RemoveAt(((List<string>)p.SongList).FindIndex(s => s.Equals(songId)));
                    return p;
                }
            }
            throw new KeyNotFoundException();
        }
    }
}
