using System.Collections;
using System;
using System.Net;

class BankSystem
{
    static bool running = true;
    static User [] users =
    {
        new User("Nando", "1234", 1000.00),
        new User("Alice", "5678", 500.00),
        new User("Bob", "9012", 750.00),  
        new User("Charlie", "3456", 1200.00),
        new User("David", "7890", 300.00)

    };

    static User currUser;
    
    static void Main()
        {
            Console.WriteLine("Enter your 4-digit PIN:");

            int pinInput;

            if (int.TryParse(Console.ReadLine(), out pinInput))
            {
                foreach (User user in users)
                {
                    if (int.Parse(user.Pin) == pinInput)
                    {
                        currUser = user;
                        Console.WriteLine($"Welcome {user.Name}!");
                        showMenu();
                        return;
                    }
                }
            }

            Console.WriteLine("Invalid PIN.");
        }

    static void showMenu()
    {
        while (running)
        {
            
            Console.WriteLine("\n--- Simple Bank System ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            object menu = Console.ReadLine();
            
            int choice;
            if (int.TryParse(menu?.ToString(), out choice))
            {
                Switch(choice);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

	static void Switch(object menu)
    {
        switch (menu)
        {
            case 1:
                Deposit();
                break;
            case 2:
                Withdraw();
                break;
            case 3:
                CheckBalance();
                break;
            case 4:
                Exit();
                break;
        }
    }

    static void Deposit()
    {
        Console.Write("Deposit amount: ");

        double amount;

        if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
        {
            currUser.Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${currUser.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Withdraw amount: ");

        double amount;

        if (double.TryParse(Console.ReadLine(), out amount) &&
            amount > 0 &&
            amount <= currUser.Balance)
        {
            currUser.Balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${currUser.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal.");
        }
    }
    
    static void CheckBalance()
    {
        Console.WriteLine($"Current balance: ${currUser.Balance}");
    }

    static void Exit()
    {
        Console.WriteLine("Exit");
        running = false;
        Console.WriteLine("Thank you for using the Simple Bank System. Goodbye!");
    }

}
