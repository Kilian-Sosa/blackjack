namespace BlackJack
{
    public class Program
    {
        private static Deck deck = new();
        private static Croupier croupier = new();
        private static BlackJackPlayer player;

        public static void Main()
        {

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("Enter your name");
            player = new BlackJackPlayer(Console.ReadLine());

            InitializeGame();

            bool hasFinished = false;
            while (!hasFinished)
            {
                string answer = AskForAnotherCard();

                if (answer == "n") hasFinished = true;
                else
                {
                    Console.Clear();
                    player.Draw(deck);
                    PrintCards();
                }
                player.CalculateScore();
                if (player.IsBust() || player.Score == 21) hasFinished = true;
            }
            
            croupier.Draw(deck);
            Console.WriteLine();
            CheckResult();
        }

        public static void InitializeGame()
        {
            Console.Clear();
            deck.Shuffle();
            croupier.Draw(deck);
            croupier.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            PrintCards();
        }

        public static void PrintCards()
        {
            croupier.PrintFirstCard();
            Console.WriteLine();
            player.Print();
            Console.WriteLine();
        }

        public static string AskForAnotherCard()
        {
            Console.WriteLine("Do you want to draw another card? (y/n)");
            string answer = string.Empty;
            while (answer != "y" && answer != "n") answer = Console.ReadLine().ToLower();
            return answer;
        }

        public static void CheckResult()
        {
            Console.Clear();
            PrintCards();
            Console.WriteLine($"Croupier Score: {croupier.Score}");
            Console.WriteLine($"{player.Name} Score: {player.Score}");
            if (player.IsBust()) Console.WriteLine("You are bust!");
            if (croupier.IsBust()) Console.WriteLine("Croupier is bust!");

            if (player.Score > croupier.Score && !player.IsBust()) Console.WriteLine("You win!");
            else if (player.Score < croupier.Score && !croupier.IsBust()) Console.WriteLine("You lose!");
            else Console.WriteLine("Draw!");
        }
    }
}