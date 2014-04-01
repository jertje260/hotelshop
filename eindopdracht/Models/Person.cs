using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace eindopdracht.Models
{
    public class Person
    {
        private int id;
        private string firstName;
        private string insertionName;
        private string lastName;
        private DateTime birthday;
        private char gender;
        public int EntryId{ get; set; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string InsertionName
        {
            get { return insertionName; }
            set { insertionName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataType(DataType.Date)]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        [RegularExpression("^[m|f]$")]
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
     
    }
}
