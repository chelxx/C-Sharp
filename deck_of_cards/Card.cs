using System;

namespace deck_of_cards
{
    public class Card
    {
        public string suit;
        public int value;
        public string StringVal
        {
            get
            {
                if (value > 1 && value < 11)
                {
                    return value.ToString();
                }
                if (value == 1)
                {
                    return "Ace";
                }
                if (value == 11)
                {
                    return "Jack";
                }
                if (value == 12)
                {
                    return "Queen";
                }
                if (value == 3)
                {
                    return "King";
                }
            }
        }
        public Card (string s, int v)
        {
            suit = s;
            value = v;
        }
    }
}