using System.Threading.Channels;

namespace Week_5
{
    internal class WordGuessingGame
    {
        static void Main(string[] args)
        {
            string[] words = { "Capgemini", "Training", "Placement", "Chandigarh", "University", "Employee", "DotNet", "Legacy", "Enrollment", "Management" };
            Random random = new Random();

            string guessWords = words[random.Next(0, words.Length)];
            char[] displayWord = new char[guessWords.Length];

            for (int i = 0; i < displayWord.Length; i++)
                displayWord[i] = '_';

            int chances = 6;
            List<char> guessedWords = new List<char>();
            Console.WriteLine("WORD GUESSING GAME");

            while (chances > 0)
            {
                Console.WriteLine("Word--" + string.Join(" ", displayWord));
                Console.WriteLine("Guessed word--" + string.Join(" ", guessedWords));
                Console.WriteLine("Chnaces--" + (chances));

                Console.WriteLine("Guess a letter that exists in the word");
                char guess = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("Enter a valid alphabet.");
                    continue;
                }

                if (guessedWords.Contains(guess))
                {
                    Console.WriteLine("Alphabet already guessed, please enter a new letter");
                    continue;
                }

                guessedWords.Add(guess);

                bool correct = false;

                for (int i = 0; i < guessWords.Length; i++)
                {
                    if (char.ToLower(guessWords[i]) == guess)
                    {
                        displayWord[i] = guessWords[i];
                        correct = true;
                    }
                }

                if (!correct)
                {
                    chances--;
                    Console.WriteLine("INCORRECT GUESS");
                }
                else
                {
                    Console.WriteLine("CORRECT GUESS");
                }

                if (!displayWord.Contains('_'))
                {
                    Console.WriteLine("\nGAME OVER");
                    Console.WriteLine("\nCongratulations!!!!!");
                    Console.WriteLine("You guessed the word--- " + guessWords);
                    return;
                }
            }
        }
    }
}
