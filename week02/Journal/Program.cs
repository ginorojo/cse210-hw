using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string option = "";

        while (option != "6")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to CSV");
            Console.WriteLine("4. Save journal to JSON");
            Console.WriteLine("5. Load journal from JSON");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to save as CSV: ");
                    string csvFilename = Console.ReadLine();
                    journal.SaveToCsv(csvFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to save as JSON: ");
                    string jsonFilename = Console.ReadLine();
                    journal.SaveToJson(jsonFilename);
                    break;
                case "5":
                    Console.Write("Enter the filename to load from JSON: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromJson(loadFilename);
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

//Improve the process of saving and loading to save as a .csv file that could be opened in Excel 
//Save or load your document in Jason storage.
