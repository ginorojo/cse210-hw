using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress on '{Name}'. +{Points} points");
    }

    public override string GetStatus()
    {
        return "[∞] " + Name;
    }
}
