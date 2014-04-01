using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{
    public class Entry
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private Room room;
        private List<Person> guests;
        private Contact contact;
        public int AmountOfPeople { get; set; }

        public Entry()
        {
            Guests = new List<Person>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<Person> Guests
        {
            get { return guests; }
            set { guests = value; }
        }
        

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

        [DataType(DataType.Date)]
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        [DataType(DataType.Date)]
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public Contact Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        
    }
}