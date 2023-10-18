namespace BlackJack
{
    public class Card
    {
        private CardSuit suit { get; set; }
        private int value { get; set; }

        public Card(CardSuit suit, int value)
        {
            suit = suit;
            value = value;
        }

        public string ToString()
        {
            return $"{value} of {suit}";
        }
    }
}
