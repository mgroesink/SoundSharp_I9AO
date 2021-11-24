using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Track
    {
        public Track()
        {
            Relation2s = new HashSet<PlaylistTracks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Albumsource { get; set; }
        public string Style { get; set; }
        public TimeSpan? Length { get; set; }

        public virtual ICollection<PlaylistTracks> Relation2s { get; set; }
    }
}
