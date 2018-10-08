using System;

namespace GuessItGame
{
    // Game inspired by Traversy Media https://www.youtube.com/watch?v=GcFJjpMFJvI
    class Program
    {
        static void Main(string[] args)
        {
            // Print App info
            string appName = "Guess It!";
            string appVersion = "1.0.0";
            string appDeveloper = "Alan Perez";

            Console.WriteLine("{0} v{1} developed by {2}", appName, appVersion, appDeveloper);
            Console.WriteLine();

            // Greet user
            Console.WriteLine("What's your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Welcome {0}, the game is simple. You will be presented with a range of numbers, your objective is to guess the number I am thinking of. Ready?", playerName);
            Console.WriteLine();

            // Begin the game
            int minNumber = 0;
            int maxNumber = 25;

            Random random = new Random();

            int answer = random.Next(minNumber, maxNumber + 1);
            int guess = -1;
            Console.WriteLine("Guess It: I am thinking of a number between {0} and {1}", minNumber, maxNumber);

            string guessInput = Console.ReadLine();

            if (!int.TryParse(guessInput, out guess)) {
                Console.WriteLine("I can only work with numbers right now :(");
            } else if (guess == answer) {
                Console.WriteLine("You got it! It was " + answer);
            } else {
                Console.WriteLine("errrmm that wasn't it");
            }
        }
    }
}
