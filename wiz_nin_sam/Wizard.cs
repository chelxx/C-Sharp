using System;
using System.Collections.Generic;

namespace wiz_nin_sam
{
    public class Wizard : Human // Wizard inherits from the Human class
    {
        public new string name { get; set; }
        public new int strength { get; set; }
        public new int intelligence { get; set; }
        public new int dexterity { get; set; }
        public new int health { get; set; }

        public Wizard(string n)
        {
            intelligence = 25;
            health = 50;
        }
        public Wizard heal(object obj) // Parameters???
        {
            // Increases Wizard's health by 10 * intelligence
            int heal = 10 * intelligence;
            health += heal;
            System.Console.WriteLine("Wizard " + name + " healed " + heal + " points!");
            // return something here
        }
        public Wizard fireball(Human enemy) // Parameters???
        {
            // Does random damage between 20 and 50
            Random rand = new Random();
            int fireball = rand.Next(20, 51);
            enemy.health -= fireball;
            System.Console.WriteLine("Fireball attack dealt " + fireball + " damage!");
            // return somethinhg here
        }

    }
}