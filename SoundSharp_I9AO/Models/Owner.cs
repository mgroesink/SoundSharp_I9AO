using SoundSharp_I9AO.Models.Annotations;
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
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Required()]
        public string Lastname { get; set; }
        [RegularExpression("[1-9][0-9]{3}[A-Z]{2}", ErrorMessage = "Illegal format for postal code. Must be like 1000XX")]
        [Required()] 
        public string Postalcode { get; set; }
        public string Street { get; set; }
        [Required()] 
        public short Housenumber { get; set; }
        public string HousenumberAdd { get; set; }
        [LicensePlateValidator()]
        public string LicensePlate { get; set; }
        [BirthdateValidator()]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Audiodevice> Audiodevices { get; set; }
    }
}
