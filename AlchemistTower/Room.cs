using System;
using System.Collections.Generic;
using System.Text;

namespace AlchemistTower
{
    internal class Room
    {
        private string name;
        private string description;

        public Room(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name {  get { return name; } }
        public string Description { get { return description; } }
    }
}
