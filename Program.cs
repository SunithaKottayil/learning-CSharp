


namespace Hangman
{
    class Program
    {
        static void Main() //  requires Main() to be static so it can start the program without creating anything first.
        {
            HangmanGame game = new HangmanGame();
            game.Play();   // Start the game loop
        }
    }
}

