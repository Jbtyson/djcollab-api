using System.Collections.Generic;
using DjCollab.Song.Data;
using DjCollab.Song.Model;

namespace DjCollab.Song
{
    public class SongService : ISongService
    {
        public void AddSongCount(string songId)
        {
            FakeSongDb.AddSongCount(songId);
        }

        public IList<SongCountInfo> GetSongCountInfo()
        {
            return FakeSongDb.GetAllSongCountInfo();
        }

        public IList<SongCountInfo> GetTopSongCountInfo(int maxResults)
        {
            return FakeSongDb.GetTopSongCountInfo(maxResults);
        }
    }
}
