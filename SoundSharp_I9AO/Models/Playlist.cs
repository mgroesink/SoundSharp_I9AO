using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Relation2s = new HashSet<Relation2>();
        }

        public short Position { get; set; }
        public int? Mp3playerSerialid { get; set; }
        public decimal PlaylistId { get; set; }

        public virtual Mp3player Mp3playerSerial { get; set; }
        public virtual ICollection<Relation2> Relation2s { get; set; }
    }
}
