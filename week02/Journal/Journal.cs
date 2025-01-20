using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Enter your mood for today: "); // Nuevo campo
        string mood = Console.ReadLine();

        Entry newEntry = new Entry
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Prompt = prompt,
            Response = response,
            Mood = mood
        };

        _entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToCsv(string filename)
    {
        try
        {
            string fullPath = Path.GetFullPath(filename);
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"\"{entry.Date}\",\"{entry.Prompt.Replace("\"", "\"\"")}\",\"{entry.Response.Replace("\"", "\"\"")}\",\"{entry.Mood.Replace("\"", "\"\"")}\"");
                }
            }

            Console.WriteLine($"Journal saved successfully to: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    public void SaveToJson(string filename)
    {
        try
        {
            string fullPath = Path.GetFullPath(filename);
            string jsonString = JsonSerializer.Serialize(_entries);
            File.WriteAllText(fullPath, jsonString);

            Console.WriteLine($"Journal saved successfully to: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    public void LoadFromJson(string filename)
    {
        try
        {
            string fullPath = Path.GetFullPath(filename);
            string jsonString = File.ReadAllText(fullPath);
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);

            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}");
        }
    }

    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(entry =>
            entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Mood.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (results.Any())
        {
            foreach (var entry in results)
            {
                Console.WriteLine(entry.ToString());
            }
        }
        else
        {
            Console.WriteLine("No matching entries found.");
        }
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
