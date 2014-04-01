using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{
    public class SpecialPrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
    }
}