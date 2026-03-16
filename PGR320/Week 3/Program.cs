using System;

class Program
{
    static void Main(string[] args)
    {
        // Dummy data
        Book book1 = new Book("The Great Gatsby", "Scribner", 1925, "F. Scott Fitzgerald");
        Book book2 = new Book("To Kill a Mockingbird", "J.B. Lippincott & Co.", 1960, "Harper Lee");
        Magazine magazine1 = new Magazine("National Geographic", "National Geographic Partners", 2024, "March 2024");
        Magazine magazine2 = new Magazine("Time", "Time Inc.", 2024, "March 2024");

        bool running = true;

        while (running)
        {
            // Exception handling
            try
            {
                Console.WriteLine("---Welcome to Library System---");
                Console.WriteLine("1. View Book 1 Info");
                Console.WriteLine("2. View Book 2 Info");
                Console.WriteLine("3. View Magazine 1 Info");
                Console.WriteLine("4. View Magazine 2 Info");
                Console.WriteLine("5. Exit");

                //get the input
                string input = Console.ReadLine();

                //handle input from user
                switch (input)
                {
                    case "1":
                        book1.DisplayInfo();
                        break;

                    case "2":
                        book2.DisplayInfo();
                        break;

                    case "3":
                        magazine1.DisplayInfo();
                        break;

                    case "4":
                        magazine2.DisplayInfo();
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        running = false; //exit loop
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            
            // Catching any unexpected exceptions
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
