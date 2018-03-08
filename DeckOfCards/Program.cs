using System;

namespace card_deck
{
    class Program // HERE WE GOOOOOO!!!
    {
        static void Main(string[] args) // This is where we call our functions
        {
            Player chelsea = new Player("Chelsea"); // Enter Chelsea! Yay!
            Deck myDeck = new Deck(); // Creates a new deck of cards
            myDeck.shuffle(); // Shuffle the deck
            chelsea.draw(myDeck); // Draw a card from the deck
            chelsea.discard(0); // Remove a card from the deck
            myDeck.deal(); // Deals a card from the deck
            myDeck.reset(); // Reset the deck of cards
        }
    }
}
