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

        public Wizard(string n) : base(person)
        {
            intelligence = 25;
            health = 50;
            System.Console.WriteLine($"The Wizard {name}'s stats are... Strength: {strength}, Intelligence: {intelligence}, Dexterity: {dexterity}, Health: {health}");

        }
        public int heal(Human user) // Parameters???
        {
            // Increases Wizard's health by 10 * intelligence
            int heal = 10 * intelligence;
            user.health += heal;
            System.Console.WriteLine($"Wizard {name} healed {heal} points!");
            return (int)health;
        }
        public int fireball(Human enemy) // Parameters???
        {
            // Does random damage between 20 and 50
            Random rand = new Random();
            int fireball = rand.Next(20, 51);
            enemy.health -= fireball;
            System.Console.WriteLine($"Fireball attack dealt {fireball} damage to {enemy}!");
            return (int)health;
        }

    }
}