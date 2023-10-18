namespace BlackJack
{
    public class Player
    {
        protected List<Card> hand { get; set; }
        protected string name { get; set; }

        public Player(string name)
        {
            hand = new List<Card>();
            this.name = name;
        }

        public virtual void Draw(Deck deck)
        {
            hand.Add(deck.Draw());
        }

        public void Print()
        {
            Console.WriteLine($"{name}'s hand:");
            foreach (Card card in hand) card.ToString();
        }
    }

    public class BlackJackPlayer: Player
    {
        protected int score { get; set; }

        public BlackJackPlayer(string name): base(name) { }

        public bool HasAce()
        {
            foreach (Card card in hand) if (card.Value == 1) return true;
            return false;
        }

        public void CalculateScore()
        {
            score = 0;
            foreach (Card card in hand) score += card.Value;
            if (HasAce() && score + 10 <= 21) score += 11;
        }   

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        public bool IsBust()
        {
            return score > 21;
        }
    }

    public class Croupier: BlackJackPlayer
    {
        public Croupier(): base("Croupier") { }

        public override void Draw(Deck deck)
        {
            while (score < 17)
            {
                base.Draw(deck);
                CalculateScore();
            }
        }

        public void PrintFirstCard()
        {
            Console.WriteLine($"{name}'s hand:");
            hand[0].ToString();
        }
    }
}