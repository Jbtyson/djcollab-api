using System;
using System.Collections.Generic;
using System.Linq;
using DjCollab.Song.Model;

namespace DjCollab.Song.Data
{
    public static class FakeSongDb
    {
        private static readonly Dictionary<string, SongCountInfo> songCounts = 
            new Dictionary<string, SongCountInfo>();

        public static void AddSongCount(string songId)
        {
            if (!songCounts.ContainsKey(songId))
            {
                songCounts[songId] = new SongCountInfo()
                {
                    SongId = songId,
                    Count = 0
                };
            }
            songCounts[songId].Count++;
        }

        public static IList<SongCountInfo> GetAllSongCountInfo()
        {
            return songCounts.Values.ToList();
        }

        public static IList<SongCountInfo> GetTopSongCountInfo(int maxResults)
        {
            throw new NotImplementedException();
        }
    }
}
