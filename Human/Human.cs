using System;

namespace human_oop
{
    public class Human
    {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int health;

        public Human(string n)
        {
            name = n;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
            Console.WriteLine($"Name: {name}, Strength: {strength}, Intelligence: {intelligence}, Dexterity: {dexterity}, Strength: {health}");
        }
        public Human(string n, int s, int i, int d, int h)
        {
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }
        public Human attack(Human enemy)
        {
            int damage = 5 * strength;
            enemy.health -= damage;
            System.Console.WriteLine($"{name} attacked {enemy.name}. {enemy.name}'s health is now {enemy.health}.");
            return enemy;
        }
    }
}