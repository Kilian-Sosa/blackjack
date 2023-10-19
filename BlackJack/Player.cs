namespace BlackJack {
    public class Player {
        protected List<Card> hand;
        protected string name;

        public Player(string name) {
            hand = new List<Card>();
            this.name = name;
        }

        public string Name {
            get { return name; }
            private set { this.name = value; }
        }

        public virtual void Draw(Deck deck) {
            hand.Add(deck.Draw());
        }

        public void Print() {
            Console.WriteLine($"{name}'s hand:");
            for (int i = 0; i < 7; i++) {
                foreach (Card card in hand)
                    Console.Write(card.ToString().Split('\n')[i] + " ");
                Console.WriteLine();
            }
        }
    }

    public class BlackJackPlayer: Player {
        protected int score;

        public BlackJackPlayer(string name): base(name) { }

        public bool HasAce() {
            foreach (Card card in hand) if (card.Value == 1) return true;
            return false;
        }

        public void CalculateScore() {
            score = 0;
            foreach (Card card in hand) 
                if (card.Value > 10) score += 10;
                else score += card.Value;
            if (HasAce() && score + 10 <= 21) score += 10;
        }   

        public int Score {
            get { return score; }
            private set { score = value; }
        }

        public bool IsBust() {
            return score > 21;
        }
        public int GetNumberOfCards() {
            return hand.Count;
        }
    }

    public class Croupier: BlackJackPlayer {
        public Croupier(): base("Croupier") { }

        public override void Draw(Deck deck) {
            while (score < 17) {
                base.Draw(deck);
                CalculateScore();
            }
        }

        public void Print(int num = 0){
            if (num == 0) base.Print();
            else  PrintFirstCard();
        }

        public void PrintFirstCard(){
            string hiddenCard = "+-------+\n|?      |\n|       |\n|   ?   |\n|       |\n|      ?|\n+-------+";
            Console.WriteLine($"{name}'s hand:");
            for (int i = 0; i < 7; i++) {
                Console.Write(hand[0].ToString().Split('\n')[i] + " ");
                Console.Write(hiddenCard.Split('\n')[i] + " ");
                Console.WriteLine();
            }
        }
    }
}