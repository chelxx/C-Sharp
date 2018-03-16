using System;

namespace Dojodachi
{
    public class Dojodachi // Class Dojodachi
    {
        // Attributes needed to create a Dojodachi
        public string name = "Michael Choi"; // It needs a name but I want it hardcoded to Michael Choi
        public int fullness; 
        public int happiness;
        public int meals;
        public int energy;
        public string status;

        public Dojodachi() // When actually creating a Dojodachi, these are its attributes and values
        {
            fullness = 20;
            happiness = 20;
            meals = 3;
            energy = 50;
            status = "Hello, my life is in your hands!";
        }
        public void feed()
        {
            // Feeding costs 1 meal and gains RANDOM fullness (5-10). Can't feed if 0 meals!
            Random rand = new Random();
            if (meals > 0)
            {
                meals = meals - 1;
                if (rand.Next(1,5) == 3) // If the Dojodachi doesn't like the food
                {
                    fullness = fullness + 0;
                    status = "Treason! You dare serve me this garbage, you fool?!";
                }
                else
                {
                    int randomfullness = rand.Next(5, 11);
                    fullness = fullness + randomfullness;
                    status = $"Delicious! More, more, more! I gained {randomfullness} Fullness points!";
                }
            }
            else
            {
                status = "No more meals so put me to work!";
            }
        }
        public void play()
        {
            // Playing costs 5 energy and gains RANDOM happiness (5-10).
            Random rand = new Random();
            if (energy > 0)
            {
                energy = energy - 5;
                if (rand.Next(1,5) == 3)
                {
                    happiness = happiness + 0;
                    status = "No! I don't want to play!";
                }
                else
                {
                    int randomhappiness = rand.Next(5, 11);
                    happiness = happiness + randomhappiness;
                    status = $"I liked playing with you! I gained {randomhappiness} Happiness points!";
                }
            }
            else
            {
                status = "Too tired... I want to nap!";
            }
        }
        public void work()
        {
            // Working costs 5 energy and earns between 1-3 meals.
            Random rand = new Random();
            if (energy > 0)
            {
                energy = energy - 5;
                int randommeals = rand.Next(1,4);
                meals = meals + randommeals;
                status = $"I earned {randommeals} Meals from working! Phew~";
            }
            else
            {
                status = "Too tired... I need to take a nap!";
            }
        }
        public void sleep()
        {
            // Sleeping costs 5 happiness and 5 fullness. It will increase energy by 15 points.
            happiness = happiness - 5;
            fullness = fullness - 5;
            status = "I gained 15 points from sleeping!";
            if (energy > 85)
            {
                energy = 100;
            }
            else
            {
                energy = energy + 15;
            }
        }
        public void reset()
        {
            // Reset the game. Reincarnation!
            fullness = 20;
            happiness = 20;
            meals = 3;
            energy = 50;
            status = "What have I done to you?! It's unnatural to play God!";
        }
    }
}