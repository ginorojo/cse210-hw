using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you defended someone.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done something like this before?",
        "How did you get started?",
        "How did you feel when you finished?",
        "What made this time different from others when you weren't as successful?",
        "What do you like most about this experience?",
        "What could you learn from this experience that could be applied to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind for the future?"
    };

    protected override void ShowStartMessage()
    {
        Console.WriteLine("Reflection Activity: This activity will help you reflect on times in your life when you demonstrated strength and resilience.");
        PauseAndCountdown();
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        ShowCountdown(false); // Show starting countdown
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);

        // Here we calculate how many questions can be asked in the available time
        int timePerQuestion = 10; // Each question and pause lasts approximately 10 seconds
        int cycles = duration / timePerQuestion;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            Thread.Sleep(10000); // 10-second pause between questions
        }

        if (duration % timePerQuestion != 0)
        {
            // If there is remaining time, wait for the remaining duration.
            Thread.Sleep(duration % timePerQuestion * 1000); // Remaining time
        }
    }

    protected override void ShowEndMessage()
    {
        ShowCountdown(true); // Show ending countdown
        Console.WriteLine("Great job! You have completed the reflection activity.");
    }
}