using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Relation2s = new HashSet<PlaylistTracks>();
        }

        public short Position { get; set; }
        public int? Mp3playerSerialid { get; set; }
        public int PlaylistId { get; set; }

        public virtual Mp3player Mp3playerSerial { get; set; }
        public virtual ICollection<PlaylistTracks> Relation2s { get; set; }
    }
}
