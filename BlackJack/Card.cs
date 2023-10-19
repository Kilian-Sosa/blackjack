namespace BlackJack
{
    public class Card
    {
        private CardSuit suit;
        private int value;

        public Card(CardSuit suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int Value
        {
            get { return value; }
            private set {
                if (value >= 10) value = 10;
                this.value = value; 
            }
        }
        private string ValueToString()
        {
            switch (value)
            {
                case 1: return "Ace";
                case 10: return "Jack";
                case 11: return "Queen";
                case 12: return "King";
                default: return value.ToString();
            }
        }

        public override string ToString()
        {
            return $"{ValueToString()} of {suit}";
        }
    }
}
