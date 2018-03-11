using System;
using System.Collections.Generic;

namespace DeckOfCards
{ 
    public class Card // Creating the class of CARD
    {
        public string stringVal; // Attribute: The cards will have string values
        public string suit; // Attribute: The cards will have a suit
        public int value; // Attribute: The cards will have values

        public Card (string su, string sv, int va) // What we need to MAKE a card:
        {
            suit = su; // It needs a suit... 
            value = va; // ...a value...
            stringVal = sv; // ...and the string value!
        }
    }
}
// Notes:
// #1: What is value for exactly? How is it different from stringVal?