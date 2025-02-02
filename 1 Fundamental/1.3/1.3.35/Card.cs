﻿namespace _1._3._35
{
    /// <summary>
    /// 扑克牌类。
    /// </summary>
    class Card
    {
        Suit suit;
        int number;

        public Card(Suit suit, int number)
        {
            this.suit = suit;
            this.number = number;
        }

        public override string ToString()
        {
            string num;
            if (this.number == 1)
            {
                num = "Ace";
            }
            else if (this.number == 11)
            {
                num = "Jack";
            }
            else if (this.number == 12)
            {
                num = "Queen";
            }
            else if (this.number == 13)
            {
                num = "King";
            }
            else
            {
                num = this.number.ToString();
            }

            return num + " of the " + this.suit.ToString();
        }
    }

    enum Suit
    {
        Clubs = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3
    };
}
