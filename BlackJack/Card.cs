namespace BlackJack {
    public class Card {
        private CardSuit suit;
        private int value;

        public Card(CardSuit suit, int value) {
            this.suit = suit;
            this.value = value;
        }

        public int Value {
            get { return value; }
            private set {
                if (value >= 10) value = 10;
                this.value = value; 
            }
        }
        private string ValueToString() {
            switch (value) {
                case 1: return "A";
                case 10: return "J";
                case 11: return "Q";
                case 12: return "K";
                default: return value.ToString();
            }
        }

        public string GetSuitIcon(){
            switch (suit)
            {
                case CardSuit.Clubs: return "\u2663";   //♣
                case CardSuit.Diamonds: return "\u2666";//♦
                case CardSuit.Hearts: return "\u2665";  //♥
                case CardSuit.Spades: return "\u2660";  //♠
                default: return "";
            }
        }

        public override string ToString() {
            string value = ValueToString();
            string cardString = $"+-------+\n|{value}      |\n|       |\n|   {GetSuitIcon()}   |\n|       |\n|      {value}|\n+-------+";
            return cardString;
            //+-------+
            //|K      |
            //|       |
            //|   ♠   |
            //|       |
            //|      K|
            //+-------+
        }
    }
}