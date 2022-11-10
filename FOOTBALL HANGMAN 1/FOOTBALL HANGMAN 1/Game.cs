using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Hangman.View;

namespace FOOTBALL 
{
    public class Game
    {
        private List<char> wordToGuess;
        private List<char> wordGuessed;
        private List<char> incorrectGuesses;

        private IVisualizer _gameVisualizer;
        private bool _isRunning = false;

        /// <summary>
        /// Creates a new Hangman game.
        /// </summary>
        /// <param name="visualizer">The Visualization Handler to use.</param>
        /// <param name="word">The hangman word to use.</param>
        public Game(IVisualizer visualizer, string word)
        {
            _gameVisualizer = visualizer;
            wordToGuess = new List<char>();
            wordGuessed = new List<char>();
            incorrectGuesses = new List<char>();

            // Setup the game with the new word.
            wordToGuess.AddRange(word);
            for (var x = 0; x < wordToGuess.Count; x++)
                wordGuessed.Add('_');

            _gameVisualizer.WelcomeScreen();
            if (!_isRunning) // For GUI visualizer.
                GameLoop();
        }

        /// <summary>
        /// Runs and handles the hangman game.
        /// </summary>
        private void GameLoop()
        {
            _isRunning = true;

            while (wordGuessed.Contains('_'))
            {
                // Game screen.
                Console.Clear();
                _gameVisualizer.RefreshGameScreen(wordGuessed, incorrectGuesses);

                // Request the users next guess.
                _gameVisualizer.RequestGuess();
                var playerGuess = Console.ReadLine().ToUpper();

                if (ValidateGuess(playerGuess))
                {
                    var guess = Convert.ToChar(playerGuess);

                    if (!wordGuessed.Contains(guess) && !incorrectGuesses.Contains(guess))
                    {
                        if (wordToGuess.Contains(guess))
                        {
                            // Handle a correct guess.
                            for (var x = 0; x < wordToGuess.Count; x++)
                            {
                                if (wordToGuess[x] == guess)
                                    wordGuessed[x] = guess;
                            }
                        }
                        else
                        {
                            // Handle an incorrect guess.
                            incorrectGuesses.Add(guess);
                            if (incorrectGuesses.Count >= 6)
                                _gameVisualizer.LoseScreen(wordToGuess);
                        }
                    }
                    else
                    {
                        _gameVisualizer.AlreadyGuessed();
                    }
                }
                else
                {
                    _gameVisualizer.InvalidGuess();
                }
            }

            // The player must have won.
            _gameVisualizer.WinScreen(wordToGuess, incorrectGuesses.Count);
        }

        /// <summary>
        /// Validates whether or not the guess is valid.
        /// </summary>
        /// <param name="guess">The users guess</param>
        /// <returns>True if the guess is valid, otherwise false.</returns>
        private static bool ValidateGuess(string guess)
        {
            // Must be alphabetical, and a single character.
            return (guess.Length == 1) && Regex.IsMatch(guess, @"^[a-zA-Z]+$");
        }
    }
}