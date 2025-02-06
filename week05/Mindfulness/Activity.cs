using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public abstract class Activity
{
    protected int duration;

    public void StartActivity()
    {
        ShowStartMessage();
        SetDuration();
        PauseBeforeStarting();
        PerformActivity();
        ShowEndMessage();
    }

    protected abstract void ShowStartMessage();
    protected abstract void PerformActivity();
    protected abstract void ShowEndMessage();

    protected void SetDuration()
    {
        Console.Write("Please enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    protected void PauseBeforeStarting()
    {
        Console.WriteLine("Get ready to start...");
        Thread.Sleep(3000); // 3-second pause
    }

    protected void ShowCountdown(bool isEnding)
    {
        if (isEnding)
        {
            Console.WriteLine("Ending in...");
        }
        else
        {
            Console.WriteLine("Starting in...");
        }
        
        for (int i = 3; i >= 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000); // 1-second pause
        }
    }

    protected void PauseAndCountdown()
    {
        Thread.Sleep(3000); // 3-second pause after each message
        ShowCountdown(false); // Show starting countdown
    }
}
