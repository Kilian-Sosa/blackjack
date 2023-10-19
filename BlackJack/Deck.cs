namespace BlackJack {
    public class Deck {
        private List<Card> cards;

        public Deck() {
            cards = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                for (int i = 1; i < 13; i++) cards.Add(new Card(suit, i));
        }

        public void Shuffle() {
            Random random = new Random();
            cards = cards.OrderBy(x => random.Next()).ToList();
        }

        public Card Draw() {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void Print() {
            foreach (Card card in cards) Console.WriteLine(card.ToString());
        }
    }
}