using System;
using System.Collections.Generic;

namespace Hangman
{
    class Hangman
    {
        int limbs = 0;
        string answer = "";
        HashSet<char> guesses = new HashSet<char>();
        string warning = "";

        // Start Game
        public void Start()
        {
            Console.Clear();
            limbs = getDifficulty();
            answer = randomAnswer();

            // Game Loops until lost or won condition met
            while ( !(isGameLost() || isGameWon()) )
            {
                display();
                getInput();
            }
            if (isGameLost()) lose(); else win();
        }

        string randomAnswer()
        {
            Random rnd = new Random();
            // Words to guess
            string[] WordBank = {
                                "aardvark", "alligator",
                                "beaver", "bear",
                                "cheetah", "chimpanzee",
                                "dolphin", "duck",
                                "eagle", "elephant",
                                "giraffe", "greyhound",
                                "hippopotamus", "horse",
                                "iguana", "impala",
                                "jaguar", "jellyfish",
                                "kangaroo", "koala",
                                "lion", "lobster",
                                "mule", "mouse",
                                "newt",
                                "octopus", "ostrich",
                                "penguin", "platypus",
                                "quail",
                                "rabbit", "rooster",
                                "salamander", "squid",
                                "tiger", "tortoise",
                                //"u",
                                "vulture",
                                "walrus", "whale",
                                //"x",
                                "yak",
                                "zebra" };
            return WordBank[rnd.Next(WordBank.Length)];
        }

        int getDifficulty()
        {
            int result = 0;
            while (result < 1 || result > 3)
            {
                Console.WriteLine("{0}Choose difficulty{0}1 - Easy{0}2 - Medium{0}3 - Hard", Environment.NewLine + "\t");
                int.TryParse(Console.ReadLine(), out result);
            }
            return 6 / result;
        }

        string displayWord()
        {
            string result = "";
            foreach (char c in answer)
            {
                if (guesses.Contains(c)) result += c;
                else result += "_ ";
            }
            return result;
        }

        string getAlphabet()
        {
            string result = "";
            for (int x = 97; x < 123; x++)
            {
                if (guesses.Contains((char)x)) result += "_";
                else result += (char)x;
            }
            return result;
        }

        void display()
        {
            Console.Clear();
            Console.WriteLine("{0}\t{1}{0}{0}\tGuesses Left: {2}{0}{0}\tLetters: {3}",
                Environment.NewLine, displayWord(), limbs, getAlphabet());

            if (warning.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(warning);
                warning = "";
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
            }

            Console.Write("Enter a Letter: ");
        }

        void getInput()
        {
            string input = Console.ReadLine();
            if (
                input.Trim().Length == 1 && (char)input.ToCharArray().GetValue(0) > 96 && (char)input.ToCharArray().GetValue(0) < 123)
            {
                if (guesses.Contains((char)input.ToCharArray().GetValue(0)))
                {
                    warning = "Already guessed that one.";
                }
                else
                {
                    guesses.Add((char)input.ToCharArray().GetValue(0));
                    if (!answer.Contains(input)) limbs -= 1;
                }
            }
            else
            {
                warning = "Invalid letter";
            }
        }

        bool isGameWon()
        {
            return !displayWord().Contains("_");
        }

        bool isGameLost()
        {
            return limbs < 1;
        }

        void win()
        {
            Console.WriteLine("{0}\tCongratulations!! It is a {1}!", Environment.NewLine, answer);
            pause();
        }

        void lose()
        {
            Console.WriteLine("{0}\tBetter luck next time! It was a {1}!", Environment.NewLine, answer);
            pause();
        }

        void pause()
        {
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}