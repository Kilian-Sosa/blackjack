namespace BlackJack {
    public class Program {
        private static Deck deck = new();
        private static Croupier croupier = new();
        private static BlackJackPlayer player;

        public static void Main() {

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("Enter your name");
            player = new BlackJackPlayer(Console.ReadLine() ?? "");

            InitializeGame();

            bool hasFinished = false;
            while (!hasFinished) {
                Console.WriteLine($"You are now at : {player.Score}");
                if (player.Score == 21) break;

                string answer = AskForAnotherCard();

                if (answer == "n") hasFinished = true;
                else {
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

        public static void InitializeGame() {
            Console.Clear();
            deck.Shuffle();
            croupier.Draw(deck);
            croupier.Draw(deck);
            croupier.CalculateScore();
            player.Draw(deck);
            player.Draw(deck);
            player.CalculateScore();
            PrintCards();
        }

        public static void PrintCards(int num = 1) {
            croupier.Print(num);
            Console.WriteLine();
            player.Print();
            Console.WriteLine();
        }

        public static string AskForAnotherCard() {
            Console.WriteLine("Do you want to draw another card? (y/n)");
            string answer = string.Empty;
            while (answer != "y" && answer != "n") answer = Console.ReadLine().ToLower();
            return answer;
        }

        public static void CheckResult() {
            Console.Clear();
            PrintCards(0);
            Console.WriteLine($"Croupier Score: {croupier.Score}");
            Console.WriteLine($"{player.Name} Score: {player.Score}");
            if (player.IsBust()) Console.WriteLine("You are bust!");
            if (croupier.IsBust()) Console.WriteLine("Croupier is bust!");

            if (player.IsBust() && croupier.IsBust() || player.Score == croupier.Score) Console.WriteLine("Draw!");
            else if (!player.IsBust() && croupier.IsBust()) Console.WriteLine("You win!");
            else if (player.IsBust() && !croupier.IsBust()) Console.WriteLine("You lose!");
            else
                if (croupier.Score < player.Score) Console.WriteLine("You win!");
                else if (player.Score < croupier.Score) Console.WriteLine("You lose!");
                else {
                    if (croupier.GetNumberOfCards() < player.GetNumberOfCards()) Console.WriteLine("You lose! Croupier won thanks to dealer's advantage!");
                    else Console.WriteLine("Draw!");
                }
        }
    }
}