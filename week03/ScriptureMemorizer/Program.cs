using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding. In all your ways acknowledge him, and he will make your paths straight.");

        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit")
                break;

            scripture.HideRandomWords(3); 
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nMemorization complete!");
    }
}