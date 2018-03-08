using System;
using System.Collections.Generic;

namespace card_deck
{ 
    public class Deck // Creating the class of DECK
    {
        public List<Card> cards = new List<Card>(); //Attribute: a deck is a list

        public Deck() // The actual making of the deck
        {
            string[] suits = {"Diamonds", "Hearts", "Spades", "Clubs"}; 
            string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

            foreach(string suit in suits) // This will cycle through each suit...
            {
                for (int i = 0; i < stringVal.Length; i++) // ...and each suit will have all 13 stringVals!
                {
                    Card newCard = new Card(suit, stringVal[i], i+1); // The card is made!
                    cards.Add(newCard); // The card is added to the deck
                    System.Console.WriteLine("Adding a new card... " + stringVal[i] + " of " + suit); // I NEED VISUALS OKAY :(
                }
            }
        }
        public Card deal() // The DEAL method
        {
            Card dealCard = cards[0]; // This takes the card at index 0 aka the first/top card
            cards.RemoveAt(0);
            return dealCard;
        }
        public void reset() // The RESET THE DECK method
        {
            List<Card> cards = new List<Card>();
            System.Console.WriteLine("Resetting the deck!");
        }
        public void shuffle() // The SHUFFLE method
        {
            Random rand = new Random(); // Random
            for (int i = 0; i < cards.Count; i++) // For loop to go through each card and shuffling it to give it a new suit and value
            {
                int shuffle = rand.Next(i, cards.Count);
                Card temp = cards[shuffle];
                cards[shuffle] = cards[i];
                cards[i] = temp;
            }
            System.Console.WriteLine("Shuffling the deck!");
        }
    }
}