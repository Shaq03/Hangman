using System;
using System.Collections.Generic;

namespace Hangman.View
{
    public class TextVisualizer : IVisualizer
    {
        /// <summary>
        /// Outputs the welcome message
        /// </summary>
        public void WelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("In Hangman your goal is to guess all the letters thaT make up");
            Console.WriteLine("the hidden word! If you get six incorrect guess you lose.");
            Console.WriteLine("Each time you guess correctly, the letter is revealed in the word.");
            Console.WriteLine("A random word is chosen at the start of the game." + Environment.NewLine);
            Console.WriteLine("Press ENTER to start the game...");
            Console.ReadLine();
        }

        /// <summary>
        /// Refresh/Output the game screen.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="incorrectGuesses">The players incorrect guesses.</param>
        public void RefreshGameScreen(IEnumerable<char> word, IEnumerable<char> incorrectGuesses)
        {
            Console.Write(Environment.NewLine + "Word: ");
            foreach (var letter in word)
                Console.Write(letter + " ");

            Console.Write(Environment.NewLine + "Incorrect Guesses: ");
            foreach (var letter in incorrectGuesses)
                Console.Write(letter + ", ");

            Console.WriteLine();
        }

        /// <summary>
        /// Outputs the losing message
        /// </summary>
        /// <param name="word">The word.</param>
        public void LoseScreen(IEnumerable<char> word)
        {
            Console.Clear();
            Console.WriteLine("You're out of guesses! You Lose!" + Environment.NewLine);
            Console.WriteLine("The word was: ");
            foreach (var letter in word)
                Console.Write(letter);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press ENTER to leave the game");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Outputs the winning message
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="incorrectGuesses">The players incorrect guesses.</param>
        public void WinScreen(IEnumerable<char> word, int incorrectGuessesCount)
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "Congratulations! You Win!");
            Console.WriteLine("You had " + incorrectGuessesCount + " incorrect guesses!" + Environment.NewLine);
            Console.WriteLine("The final word was: ");
            foreach (var letter in word)
                Console.Write(letter);
            Console.ReadLine();
        }

        /// <summary>
        /// Outputs message requesting the users guess.
        /// </summary>
        public void RequestGuess()
        {
            Console.WriteLine(Environment.NewLine + "Enter a guess");
        }

        /// <summary>
        /// Outputs message stating the users already guessed the letter.
        /// </summary>
        public void AlreadyGuessed()
        {
            Console.WriteLine(Environment.NewLine + "You have already guessed that letter!");
        }

        /// <summary>
        /// Outputs message stating the users guess is invalid.
        /// </summary>
        public void InvalidGuess()
        {
            Console.WriteLine(Environment.NewLine + "Invalid Guess. Guesses must be a single alphabetical letter.");
        }
    }
}