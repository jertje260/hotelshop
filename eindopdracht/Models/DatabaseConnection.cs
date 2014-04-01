using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eindopdracht.Models
{
    public class DatabaseConnection:DbContext
    {
        public DatabaseConnection()
            : base("DefaultConnection")
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SpecialPrice> SpecialPrices { get; set; }
        public DbSet<Person> People { get; set; }

    }
}