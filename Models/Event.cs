using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSystem
{
    public class Event
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        private static int nextID = 1;

        public Event (string name, string description, string date, string location, double price, string imageURL)
        {
            this.Id = nextID++;
            this.Name = name;
            this.Description = description;
            this.Date = date;
            this.Location = location;
            this.Price = price;
            this.ImageURL = imageURL;
        }

    }
}