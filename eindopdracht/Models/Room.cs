using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{

    public class Room
    {
        private int id;
        private int amountOfPeople;
        private int minimumPrice;
        public List<SpecialPrice> specialPrices { get; set; }

        public Room()
        {
            specialPrices = new List<SpecialPrice>();
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [RegularExpression("^[2,3,5]$")]
        public int AmountOfPeople
        {
            get { return amountOfPeople; }
            set { if (value == 2 || value == 3 || value == 5) { amountOfPeople = value; } }
        }

        public int MinimumPrice
        {
            get { return minimumPrice; }
            set { minimumPrice = value; }
        }


        
    }
}