using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Memorecorder
    {
        public int Id { get; set; }
        public string MaxCartridgeType { get; set; }

        public virtual Audiodevice AudioDevice { get; set; }
    }
}
