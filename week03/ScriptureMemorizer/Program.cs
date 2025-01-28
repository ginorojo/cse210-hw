// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "scriptures.txt";
        List<Scripture> scriptures = LoadScripturesFromFile(filePath);

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available.");
            return;
        }

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (!selectedScripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.DisplayText);

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("Final Scripture:");
        Console.WriteLine(selectedScripture.DisplayText);
        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 5)
            {
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4];

                var reference = new ScriptureReference(book, chapter, startVerse, endVerse);
                scriptures.Add(new Scripture(reference, text));
            }
        }

        return scriptures;
    }
}

//the program load scriptures from a file #scriptures.txt