using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoundSharp_I9AO.Models.ViewModels
{
    public class MemoRecorderViewModel
    {
        // Properties van AudioDevice

        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        [DataType(DataType.Currency)]
        public decimal? PriceExBtw { get; set; }
        public decimal? Btw { get; set; }
        public int OwnerId { get; set; }

        public string MaxCartridgeType { get; set; }
    }
}
