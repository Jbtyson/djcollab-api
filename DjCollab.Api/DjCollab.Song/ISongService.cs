using System.Collections.Generic;
using DjCollab.Song.Model;

namespace DjCollab.Song
{
    public interface ISongService
    {
        void AddSongCount(string songId);
        IList<SongCountInfo> GetSongCountInfo();
        IList<SongCountInfo> GetTopSongCountInfo(int maxResults);
    }
}
