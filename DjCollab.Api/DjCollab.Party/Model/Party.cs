using System;
using System.Collections;
using System.Collections.Generic;

namespace DjCollab.Party.Model
{
    public class Party
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public string Name { get; set; }
        public IList<int> SongList { get; set; }
    }
}
