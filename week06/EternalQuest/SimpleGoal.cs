using System;

class SimpleGoal : Goal
{
    private bool IsCompleted;

    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}
