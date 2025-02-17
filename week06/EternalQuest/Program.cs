using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEternal Quest Goal Tracker");
            Console.WriteLine("1. Add Simple Goal");
            Console.WriteLine("2. Add Eternal Goal");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Display Goals");
            Console.WriteLine("6. Show Total Score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string simpleName = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int simplePoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new SimpleGoal(simpleName, simplePoints));
                    break;

                case "2":
                    Console.Write("Enter goal name: ");
                    string eternalName = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int eternalPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new EternalGoal(eternalName, eternalPoints));
                    break;

                case "3":
                    Console.Write("Enter goal name: ");
                    string checklistName = Console.ReadLine();
                    Console.Write("Enter points per event: ");
                    int checklistPoints = int.Parse(Console.ReadLine());
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(checklistName, checklistPoints, targetCount, bonusPoints));
                    break;

                case "4":
                    Console.Write("Enter goal name to record event: ");
                    string recordName = Console.ReadLine();
                    manager.RecordGoalEvent(recordName);
                    break;

                case "5":
                    Console.WriteLine("\nYour Goals:");
                    manager.ShowGoals();
                    break;

                case "6":
                    manager.ShowScore();
                    break;

                case "7":
                    Console.Write("Enter filename to save goals: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    Console.WriteLine("Goals saved successfully.");
                    break;

                case "8":
                    Console.Write("Enter filename to load goals: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    Console.WriteLine("Goals loaded successfully.");
                    break;

                case "9":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
