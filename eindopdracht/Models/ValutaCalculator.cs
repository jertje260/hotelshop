using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{
    public class ValutaCalculator
    {
        private readonly double eurotodollar = 1.36;
        private readonly double eurotoyen = 142.66;

        public ValutaCalculator()
        {
        }

        public double getDollars(int euros)
        {
            return (euros * eurotodollar);
        }

        public double getYens(int euros)
        {
            return (euros * eurotoyen);
        }
    }
}