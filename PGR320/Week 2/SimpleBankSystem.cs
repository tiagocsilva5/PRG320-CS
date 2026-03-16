/*using System.Collections;
using System;
using System.Net;

class SimpleBankSystem
{
    static bool running = true;
    static int pin;
    static int correctPin = 1234; //set correct pin
    static double balance = 1000.00; //set initial balance
    
    static void Main()  //main method
    {
        int attempts = 0;

        while (attempts < 3) //if more than 3 wrong attempts, access denied
        {
            Console.Write("Enter your 4-digit PIN: ");
            
            if (int.TryParse(Console.ReadLine(), out pin) && pin == correctPin)
            {
                Console.WriteLine("PIN accepted. Welcome!");
                showMenu();
                return;
            }
            else
            {
                attempts++;
                Console.WriteLine("Invalid PIN. Please try again.");
            }
        }

        Console.WriteLine("Too many attempts. Access Denied.");
    }

    static void showMenu() //method to show menu options
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
                Switch(choice); //call switch method to choose menu option
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

	static void Switch(object menu) //method to switch between menu options
    {
        switch (menu)
        {
            case 1: //if user selects 1, call deposit method
                Deposit();
                break;
            case 2: //if user selects 2, call withdraw method
                Withdraw();
                break;
            case 3: // if user selects 3, call check balance method
                CheckBalance();
                break;
            case 4: //if user selects 4, call exit method
                Exit();
                break;
        }
    }

    static void Deposit()
    {
        Console.WriteLine("Deposit amount: ");
        double amount;
        if (double.TryParse(Console.ReadLine(), out amount) && amount > 0) //if user enters a valid amount, add to balance
        {
            balance += amount;
            Console.WriteLine($"Successfully deposited ${amount}. New balance: ${balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
        }
    }

    static void Withdraw()
    {
        Console.WriteLine("Withdraw amount: ");
        double amount;
        if (double.TryParse(Console.ReadLine(), out amount) && amount > 0 && amount <= balance) //if user enters a valid amount and has enough balance, subtract from balance
        {
            balance -= amount;
            Console.WriteLine($"Successfully withdrew ${amount}. New balance: ${balance}");
        }
        else
        {
            Console.WriteLine("No funds available. Please enter a valid amount.");
        }
    }

    static void CheckBalance()
    {
        Console.WriteLine($"Current balance: ${balance}"); //display current balance
    }

    static void Exit()
    {
        Console.WriteLine("Exit"); //display exit message and set running to false to end program
        running = false;
        Console.WriteLine("Thank you for using the Simple Bank System. Goodbye!");
    }

}
*/