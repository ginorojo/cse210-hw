using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class BreathingActivity : Activity
{
    protected override void ShowStartMessage()
    {
        Console.WriteLine("Breathing Activity: This activity will help you relax as you inhale and exhale slowly. Clear your mind and focus on your breathing.");
        PauseAndCountdown();
    }

    protected override void PerformActivity()
    {
        // The full cycle (Inhale + Exhale + Pause) should last less than the total duration.
        int cycleDuration = 8; // Each cycle (Inhale + Exhale + 3-second Pause) lasts 8 seconds

        int cycles = duration / cycleDuration; // Calculate how many cycles fit into the total duration.

        ShowCountdown(false); // Show starting countdown

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Inhale...");
            Thread.Sleep(4000); // 4-second pause for inhaling
            Console.WriteLine("Exhale...");
            Thread.Sleep(4000); // 4-second pause for exhaling

            // After exhaling, we pause for 3 seconds
            PauseAndCountdown();
        }

        if (duration % cycleDuration != 0)
        {
            // If there is remaining time, finish with one last inhale.
            Console.WriteLine("Inhale...");
            Thread.Sleep(duration % cycleDuration); // Remaining time
        }
    }

    protected override void ShowEndMessage()
    {
        ShowCountdown(true); // Show ending countdown
        Console.WriteLine("Great job! You have completed the breathing activity.");
    }
}