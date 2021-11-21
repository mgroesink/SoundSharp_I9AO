using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Audiodevices = new HashSet<Audiodevice>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        [RegularExpression("[1-9][0-9]{3}[A-Z]{2}", ErrorMessage = "Illegal format for postal code. Must be like 1000XX")]
        public string Postalcode { get; set; }
        public string Street { get; set; }
        public short Housenumber { get; set; }
        public string HousenumberAdd { get; set; }

        public virtual ICollection<Audiodevice> Audiodevices { get; set; }
    }
}
