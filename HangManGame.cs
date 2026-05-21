namespace Hangman
{
    public class HangmanGame
    {
        public string RandomWord;
        public char[] WordLength;
        public int WrongCount = 0;

        public HangmanGame()
        {
            Random random = new Random();
            RandomWord = WordList.Words[random.Next(WordList.Words.Length)];

            WordLength = new char[RandomWord.Length];

            for (int i = 0; i < WordLength.Length; i++)
            {
                WordLength[i] = '_';
            }
        }

        public char GuessLetter()
        {
        Console.Write("Guess a letter: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return '\0';

            return input.Trim().ToLower()[0];
        }

        public bool CheckLetter(char guess)
        {
            bool found = false;

            for (int i = 0; i < RandomWord.Length; i++)
            {
                if (RandomWord[i] == guess)
                {
                    WordLength[i] = guess;
                    found = true;
                }
            }

            if (!found)
                WrongCount++;

            return found;
        }

        public void DrawHangman()
        {
            switch (WrongCount)
            {
                case 1: Console.WriteLine("  O"); break;
                case 2: Console.WriteLine("  O\n  |"); break;
                case 3: Console.WriteLine("  O\n /|"); break;
                case 4: Console.WriteLine("  O\n /|\\"); break;
                case 5: Console.WriteLine("  O\n /|\\\n /"); break;
                case 6: Console.WriteLine("  O\n /|\\\n / \\"); break;
            }
        }

        public void Play()
        {
            while (true)
            {
                Console.WriteLine(new string(WordLength));

                char guess = GuessLetter();
                if (guess == '\0')
                    continue;

                bool correct = CheckLetter(guess);

                Console.WriteLine(correct ? "✔Correct!" : "Wrong! Mistakes: " + WrongCount);

                DrawHangman();

                if (new string(WordLength) == RandomWord)
                {
                    Console.WriteLine("🏆You win! The word was: " + RandomWord);
                    break;
                }

                if (WrongCount >= 6)
                {
                    Console.WriteLine("🤷‍♂️ You lost! The word was: " + RandomWord);
                    break;
                }
            }
        }
    }
}
