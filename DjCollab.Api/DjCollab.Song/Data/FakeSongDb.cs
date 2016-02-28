using System.Collections.Generic;

namespace DjCollab.Song.Data
{
    public static class FakeSongDb
    {
        private static readonly Dictionary<string, int> songCounts = new Dictionary<string, int>();

        public static void AddSongCount(string songId)
        {
            if (!songCounts.ContainsKey(songId))
            {
                songCounts[songId] = 0;
            }
            songCounts[songId]++;
        }
    }
}
