using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Audiodevice
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public decimal? PriceExBtw { get; set; }
        public decimal? Btw { get; set; }
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual Cddiscman Cddiscman { get; set; }
        public virtual Memorecorder Memorecorder { get; set; }
        public virtual Mp3player Mp3player { get; set; }
    }
}
