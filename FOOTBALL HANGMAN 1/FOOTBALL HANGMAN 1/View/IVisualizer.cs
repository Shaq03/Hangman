using System.Collections.Generic;

namespace Hangman.View
{
    public interface IVisualizer
    {
        void WelcomeScreen();
        void RefreshGameScreen(IEnumerable<char> word, IEnumerable<char> incorrectGuesses);
        void LoseScreen(IEnumerable<char> word);
        void WinScreen(IEnumerable<char> word, int incorrectGuessesCount);
        void RequestGuess();
        void AlreadyGuessed();
        void InvalidGuess();
    }
}