namespace BlackJack
{
    public class Card
    {
        private CardSuit suit { get; set; }
        private int value { get; set; }

        public Card(CardSuit suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int Value
        {
            get { return value; }
            private set { this.value = value; }
        }

        public string ToString()
        {
            return $"{value} of {suit}";
        }
    }
}
