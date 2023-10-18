namespace BlackJack
{
    public class Card
    {
        private CardSuit Suit { get; set; }
        private int Value { get; set; }

        public Card(CardSuit suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
