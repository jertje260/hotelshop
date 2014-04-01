using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{
    public class BookViewModel
    {
        public int ContactID { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        [RegularExpression("^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }
        public int EntryID { get; set; }
        public int AmountOfPeople { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Room room { get; set; }
        public List<Person> Guests { get; set; }

        public BookViewModel()
        {
            Guests = new List<Person>();
        }
    }
}