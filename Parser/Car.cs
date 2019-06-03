using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Car
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public Car()
        {
            //name = "";
        }
        public Car(string _name)
        {
            Name = _name;
        }
    }
}
