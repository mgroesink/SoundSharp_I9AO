using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Mp3player
    {
        public Mp3player()
        {
            Playlists = new HashSet<Playlist>();
        }

        public int Serialid { get; set; }
        public int? Mbsize { get; set; }
        public int Displaywidth { get; set; }
        public int Displayheight { get; set; }

        public virtual Audiodevice AudioDevice { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
