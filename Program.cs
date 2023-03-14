namespace numberguesser
{
    internal class Program
    {
        static void Main()
        {
            bool Help = false;
            int guess;
            int min = 0;
            int max = 100;
            Random random = new Random();
            int gennum = (int)random.NextInt64(min, max);
            int guessCount = 0;
            Console.WriteLine("Guess! (0-100)");
            do
            {
                void tryGuess()
                {
                    string? raw = Console.ReadLine();
                    try { guess = Convert.ToInt32(raw); }
                    catch
                    {
                        bool invokedH = false;
                        if(raw.ToLower() == "help" || raw.ToLower() == "hint")
                        {
                            if(!Help) Console.WriteLine("Here is your help. The number you are looking for is " + ((gennum % 2) == 1 ? "odd" : "even") + ". Guess again:");
                            if (Help) Console.WriteLine("Remember, the number you are looking for is " + ((gennum % 2) == 1 ? "odd" : "even") + ". Guess again:");
                            Help = true;
                            invokedH = true;
                        }
                        if (!invokedH) Console.WriteLine("You need a number! Guess Again:");
                        tryGuess();
                    }
                }
                tryGuess();
                guessCount++;
                if (guess == gennum) break;
                string toWrite = "Lower! ";
                if (guess < gennum) toWrite = "Higher! ";
                Console.WriteLine(toWrite + "Guess again:");
            }
            while (guess != gennum);
            for (int i = 0; i < 30; i++) Console.WriteLine("\n");
            Console.WriteLine("You guessed it! The number was " + gennum + ". Guesses: " + guessCount);
        }
    }
}