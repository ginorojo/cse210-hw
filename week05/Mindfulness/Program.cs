using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            if (option == "4")
            {
                // Exit message when user chooses to exit
                Console.WriteLine("Thank you for using the application. Goodbye!");
                break; // Exit the loop
            }

            Activity activity = null;
            switch (option)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}