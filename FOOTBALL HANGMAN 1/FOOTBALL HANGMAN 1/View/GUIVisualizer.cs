using System.Collections.Generic;

namespace Hangman.View
{
    public class GUIVisualizer : IVisualizer
    {
        // ToDo: Add GUI (WPF) Visuals.

        public void WelcomeScreen() { }
        public void RefreshGameScreen(IEnumerable<char> word, IEnumerable<char> incorrectGuesses) { }
        public void LoseScreen(IEnumerable<char> word) { }
        public void WinScreen(IEnumerable<char> word, int incorrectGuessesCount) { }
        public void RequestGuess() { }
        public void AlreadyGuessed() { }
        public void InvalidGuess() { }
    }
}