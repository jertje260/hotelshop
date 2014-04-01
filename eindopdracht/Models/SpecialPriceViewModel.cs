using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eindopdracht.Models
{
    public class SpecialPriceViewModel
    {
        public int RoomId { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}