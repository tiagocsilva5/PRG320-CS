using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static string filePath ="libraryData.txt";
    static List<ILibraryItem> libraryItems = new List<ILibraryItem>();
    
    static void Main(string[] args)
    {

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        LoadFromFile();

        bool running = true;

        while (running)
        {
            try
            {
                Console.WriteLine("\n--- Library System ---");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Show All Items");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Sort by Title");
                Console.WriteLine("6. Sort by Year");
                Console.WriteLine("7. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddItem();
                        break;

                    case "2":
                        RemoveItem();
                        break;

                    case "3":
                        DisplayAll();
                        break;

                    case "4":
                        SearchItems();
                        break;

                    case "5":
                        SortByTitle();
                        break;

                    case "6":
                        SortByYear();
                        break;

                    case "7":
                        SaveToFile();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void SaveToFile()
    {
        List<string> lines = new List<string>();

        foreach (var item in libraryItems)
        {

        if(item is Book b)
        {
            lines.Add($"Book|{b.Title}, {b.Publisher}, {b.PublicationYear}, {b.Author}");
        }
        else if(item is Magazine m)
        {
            lines.Add($"Magazine|{m.Title}, {m.Publisher}, {m.PublicationYear}, {m.IssueNumber}");
        }
        else if(item is Newspaper n)
        {
            lines.Add($"Newspaper|{n.Title}, {n.Publisher}, {n.PublicationYear}, {n.Date}");
        }
    
        }

        File.WriteAllLines(filePath, lines);

    }

    static void LoadFromFile()
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            if (parts[0] == "Book")
            {
                libraryItems.Add(new Book(parts[1], parts[2], int.Parse(parts[3]), parts[4]));
            }
            else if (parts[0] == "Magazine")
            {
                libraryItems.Add(new Magazine(parts[1], parts[2], int.Parse(parts[3]), parts[4]));
            }
            else if (parts[0] == "Newspaper")
            {
                libraryItems.Add(new Newspaper(parts[1], parts[2], int.Parse(parts[3]), parts[4]));
            }
        }
    }

    static void RemoveItem()
    {
        Console.WriteLine("Enter the title of the item to remove:");
        string titleToRemove = Console.ReadLine();

        var itemToRemove = libraryItems.FirstOrDefault(item => item.Title.ToLower() == titleToRemove.ToLower());

        if (itemToRemove != null)
        {
            libraryItems.Remove(itemToRemove);
            Console.WriteLine($"Item '{titleToRemove}' removed.");
            SaveToFile(); // Update the file after removal
        }
        else
        {
            Console.WriteLine($"Item '{titleToRemove}' not found.");
        }
    }

    static void DisplayAll()
    {
        foreach (var item in libraryItems)
        {
            item.DisplayInfo();
        }
    }

    static void SearchItems()
    {
        Console.WriteLine("Enter the title to search: ");
        string searchTitle = Console.ReadLine().ToLower();
        
        var results = libraryItems.Where(item => item.Title.ToLower().Contains(searchTitle));
        
        foreach (var item in results)
        {
            item.DisplayInfo();
        }
    }

    static void AddItem()
    {
        Console.WriteLine("Enter type (Book/Magazine/Newspaper): ");
        string type = Console.ReadLine();

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());

        if (type.ToLower() == "book")
        {
            Console.Write("Author: ");
            string author = Console.ReadLine();

            libraryItems.Add(new Book(title, publisher, year, author));
        }
        else if (type.ToLower() == "magazine")
        {
            Console.Write("Issue Number: ");
            string issue = Console.ReadLine();

            libraryItems.Add(new Magazine(title, publisher, year, issue));
        }
        else if (type.ToLower() == "newspaper")
        {
            Console.Write("Date: ");
            string date = Console.ReadLine();

            libraryItems.Add(new Newspaper(title, publisher, year, date));
        }

        SaveToFile();
    }

        static void SortByTitle()
    {
        var sorted = libraryItems.OrderBy(i => i.Title);

        foreach (var item in sorted)
        {
            item.DisplayInfo();
        }
    }

    //sort items by year
    static void SortByYear()  
    {
        var sorted = libraryItems.OrderBy(i => i.PublicationYear);

        foreach (var item in sorted)
        {
            item.DisplayInfo();
        }
    }
}
