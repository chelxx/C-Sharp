using System;
namespace oopDemo
{
    public class Wizard
    {
        public string house;
        public string name;

        public int health;

    

        public Wizard(string h, string n)
        {
            house = h;
            name = n;
            health = 100;
        }
        public Wizard(string h, string n, int ht)
        {
            house = h;
            name = n;
            health = ht;
        }
        public Wizard stupefy(Wizard enemy)
        {
            Random rand = new Random();
            int damage = rand.Next(5,11);
            enemy.health -= damage;
            System.Console.WriteLine($"{name} attacked {enemy.name}. Health is now {enemy.health}");
            return enemy;
        }

    }
}