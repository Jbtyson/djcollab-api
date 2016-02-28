using System.Collections.Generic;

namespace DjCollab.Party
{
    public interface IPartyService
    {
        Model.Party GetParty(int partyId);
        IList<Model.Party> GetAllParties();
        Model.Party CreateParty(string name);
        Model.Party AddSongToParty(int senderId, int partyId, int songId);
    }
}
