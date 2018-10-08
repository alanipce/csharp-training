using System;

namespace GuessItGame
{
    // Game inspired by Traversy Media https://www.youtube.com/watch?v=GcFJjpMFJvI
    class Program
    {
        static void Main(string[] args)
        {
            PrintGameInfo();
            string playerName = GatherPlayerDetails();

            // Begin the game
            int minNumber = 0;
            int maxNumber = 25;
            int attemptLimit = 5;

            Game game = new Game(minNumber, maxNumber, attemptLimit);

            int guess = -1;
            Console.WriteLine("Guess It: I am thinking of a number between {0} and {1}", minNumber, maxNumber);

            while (!game.ReachedAttemptLimit()) {
                string guessInput = Console.ReadLine();

                if (!int.TryParse(guessInput, out guess))
                {
                    Console.WriteLine("I can only work with numbers right now :(");
                }
                else if (game.CheckGuess(guess))
                {
                    Console.WriteLine("You got it! It was " + guess);
                    break;
                }
                else
                {
                    Console.WriteLine("errrmm that wasn't it");
                }

                Console.WriteLine("You have {0} attempts left", game.GetRemaingNumberOfAttempts());
            }

            Console.WriteLine("Thanks for playing {0}", playerName);

        }

        static void PrintGameInfo() {
            // Print App info
            string appName = "Guess It!";
            string appVersion = "1.0.0";
            string appDeveloper = "Alan Perez";

            Console.WriteLine("{0} v{1} developed by {2}", appName, appVersion, appDeveloper);
            Console.WriteLine();
        }

        static string GatherPlayerDetails() {
            // Greet user
            Console.WriteLine("What's your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Welcome {0}, the game is simple. You will be presented with a range of numbers, your objective is to guess the number I am thinking of. Ready?", playerName);
            Console.WriteLine();

            return playerName;
        }
    }
}
