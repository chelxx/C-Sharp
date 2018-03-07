using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        public Deck()
        {
            createCardDeck();
        }
        public void createCardDeck()
        {
            cards = new List<Card>();
            string[] deckSuits = {"Spade", "Hearts", "Clubs", "Diamonds"};
            foreach (string suit in deckSuits)
            {
                for (int i = 1; i < 14; i++)
                {
                    cards.Add(new Card(i, suit));
                }
            }
        }
        public Card Deal()
        {
            Card top = cards[0];
            cards.Remove(top);
            return top;
        }
        public void reset()
        {
            cards = new List<Card>();
            createCardDeck();
        }
    }
}