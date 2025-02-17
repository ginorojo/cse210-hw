using System;

class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int BonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        int totalPoints = Points;

        if (CurrentCount == TargetCount)
        {
            totalPoints += BonusPoints;
            Console.WriteLine($"Goal '{Name}' completed! Bonus +{BonusPoints} points");
        }

        Console.WriteLine($"Recorded progress on '{Name}'. +{totalPoints} points");
    }

    public override string GetStatus()
    {
        return CurrentCount >= TargetCount ? $"[X] {Name} (Completed)" : $"[ ] {Name} ({CurrentCount}/{TargetCount})";
    }
}
