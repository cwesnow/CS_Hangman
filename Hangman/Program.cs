using System;

namespace Hangman
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "{0}{0}\tAre you ready to play a game of Hangman? [y/n]",
                    Environment.NewLine);

                if (Console.ReadLine().StartsWith("y"))
                {
                    Hangman game = new Hangman();
                    game.Start();
                }
                else break;
            }
        }
    }
}