using System.Collections.Generic;

namespace DjCollab.Party
{
    public interface IPartyService
    {
        Model.Party GetParty(int partyId);
        Model.Party CreateParty(int userId, Model.Party party);
        Model.Party AddSongToParty(int partyId, int songId);
    }
}
