using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipHunter
{
    class Ship
    {
        public Ship(string type, int length, string[] location)
        {
            Type = type;
            Length = length;
            Location = location;
            Health = length;
        }
        public string Type { get; set; }
        public int Length { get; set; }
        public string[] Location { get; set; } // ["A2" "A3"
        public int Health { get; set; }
    }
}
