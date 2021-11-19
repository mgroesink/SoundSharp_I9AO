using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Relation2
    {
        public int TrackId { get; set; }
        public decimal PlaylistPlaylistId { get; set; }

        public virtual Playlist PlaylistPlaylist { get; set; }
        public virtual Track Track { get; set; }
    }
}
