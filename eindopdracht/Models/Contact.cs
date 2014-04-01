using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace eindopdracht.Models
{
    public class Contact
    {
        private int id;
        private string adress;
        private string zipCode;
        private string town;
        private string email;

        [RegularExpression("^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        

        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }
        
    }
}
