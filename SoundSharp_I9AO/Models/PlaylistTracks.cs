using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class PlaylistTracks
    {
        public int TrackId { get; set; }
        public int PlaylistPlaylistId { get; set; }

        public virtual Playlist PlaylistPlaylist { get; set; }
        public virtual Track Track { get; set; }
    }
}
