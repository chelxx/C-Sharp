using System;
using System.Collections.Generic;

namespace wiz_nin_sam
{
    public class Samurai : Human // Ninja inherits from the Human class
    {
        public new string name { get; set; }
        public new int strength { get; set; }
        public new int intelligence { get; set; }
        public new int dexterity { get; set; }
        public new int health { get; set; }

        public Samurai(string n)
        {
            name = n;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 200;
        }
        public Samurai death_blow() // Parameters???
        {
            // Attacks an object and reduce's targets health to 0 if target's health is less than 50
        }
        public Samurai meditate() // Parameters???
        {
            // Heals Samurai back to full health
        }

    }
}