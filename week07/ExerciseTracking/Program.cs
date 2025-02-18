using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("18 Feb 2025", 30, 4.8),
            new Cycling("18 Feb 2025", 45, 20.0),
            new Swimming("18 Feb 2025", 25, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
