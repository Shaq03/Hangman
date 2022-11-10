using Hangman.View;


namespace FOOTBALL
{
    class Program
    {

        // Possible words the user has to guess
        private static readonly string[] HangmanWords = {
            "ATTACKER", "BICYCLE KICK", "BACK HEEL", "BACK PASS", "CORNER KICK", "CROSS", "CENTER SPOT", "CHIP SHOT", "CLEARING", "COUNTER ATTACK",
            "DEFENDER", "DRIBBLE", "DROP BALL", "EQUALISER", "EXTRA TIME", "FOUL", "FREE KICK", "FIELD", "FULL TIME", "GOAL KICK",
            "GOAL LINE", "HANDBALL", "HAT TRICK", "HEADER", "INJURY TIME", "JOCKEY", "LINESMAN", "MARK", "NEAR POST", "NUTMEG",
             "OFFSIDE", "OVERLAP", "OWN GOAL", "PLAY OFF", "POSSESSION", "POACHER", "RED CARD", "SET PLAY", "SKIPPER", "SUBSTITUTION",
            "TARGET MAN", "TREBLE", "VOLLEY", "WALL", "WARM UP", "YELLOW CARD",
        };

        static void Main(string[] args)
        {
            
            var random = new Random();
            var visualizer = new TextVisualizer();
            var game = new Game(visualizer, HangmanWords[random.Next(HangmanWords.Length)]);
        }
    }
}