using System;
using System.Collections.Generic;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Cddiscman
    {
        public int Id { get; set; }
        public int Mbsize { get; set; }
        public int Displaywidth { get; set; }
        public int Displayheight { get; set; }
        public bool IsEjected { get; set; }

        public virtual Audiodevice AudioDevice { get; set; }
    }
}
