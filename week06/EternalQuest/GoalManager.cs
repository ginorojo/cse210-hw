using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int Score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                Score += goal.Points;
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {Score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(Score);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            Score = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length < 3) continue;

                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(name, points));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(name, points));
                        break;
                    case "ChecklistGoal":
                        int targetCount = int.Parse(parts[3]);
                        int bonusPoints = int.Parse(parts[4]);
                        goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                        break;
                }
            }
        }
    }
}
