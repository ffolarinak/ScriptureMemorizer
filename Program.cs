
using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";

        Scripture scripture = new Scripture(reference, text);

        // Creativity: Added a hint feature that reveals one randomly
        // hidden word to help users practise memorizing the scripture.

        string input = "";

        while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase)
               && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press Enter to hide 3 words, type 'hint' to reveal a word, or type 'quit' to exit.");

            input = Console.ReadLine() ?? "";

            if (input.Equals("hint", StringComparison.OrdinalIgnoreCase))
            {
                scripture.ShowRandomWord();
            }
            else if (!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();

        Console.WriteLine("Thank you for using Scripture Memorizer!");
    }
}
