using System;
using System.Collections.Generic;

namespace card_deck
{ 
    public class Player // Creating the class of Player
    {
        public string name; // Attribute: a player needs a name
        public List<Card> playerHand = new List<Card>(); // Attribute: a player needs to be able to hold cards

        public Player(string n) // The actual making of a player
        {
            name = n;
            System.Console.WriteLine($"{name} joins the game!");
        }
        public Card draw(Deck deck) // The player's DRAW method, connects to Deck's DEAL method
        {
            Card playerCard = deck.deal(); 
            playerHand.Add(playerCard);
            System.Console.WriteLine("Drawing! You got " + playerCard); // HOW TO MAKE THIS SHOW UP IN TERMINAL
            return playerCard; 
        }
        public Card discard(int i) // The player's DISCARD method
        {
            Card playerDiscard = playerHand[i];
            playerHand.RemoveAt(i);
            return playerDiscard;
        }
    }
}