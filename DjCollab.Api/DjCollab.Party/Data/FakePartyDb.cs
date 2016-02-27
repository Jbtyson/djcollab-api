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
            return parties.Where(p => p.Id == partyId).ToList()[0];
        }

        public static void Reset()
        {
            parties.Clear();
            nextId = 0;
        }
    }
}
