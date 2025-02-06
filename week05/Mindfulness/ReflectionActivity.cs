using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When did you feel the Holy Spirit this month?",
        "Who are some of your personal heroes?"
    };

    protected override void ShowStartMessage()
    {
        Console.WriteLine("Listing Activity: This activity will help you reflect on the good things in your life by listing as many things as you can in a given area.");
        PauseAndCountdown();
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        ShowCountdown(false); // Show starting countdown
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);

        DateTime start = DateTime.Now;

        int count = 0;
        while (DateTime.Now.Subtract(start).TotalSeconds < duration)
        {
            Console.Write("Type a response: ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You have listed {count} items.");
    }

    protected override void ShowEndMessage()
    {
        ShowCountdown(true); // Show ending countdown
        Console.WriteLine("Great job! You have completed the listing activity.");
    }
}
