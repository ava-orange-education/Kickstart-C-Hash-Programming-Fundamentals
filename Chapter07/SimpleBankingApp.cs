using System;

class Program
{
    static void Main(string[] args)
    {
        double balance = 100.00;
        bool keepRunning = true;

        while (keepRunning)
        {
            int choice = DisplayMenu();

            if (choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid selection. Please enter a number between 1 and 4.\n");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ShowBalance(balance);
                    break;

                case 2:
                    double depositAmount = GetTransactionAmount("Deposit");
                    balance = Deposit(balance, depositAmount);
                    Console.WriteLine("Deposit successful.\n");
                    break;

                case 3:
                    double withdrawAmount = GetTransactionAmount("Withdraw");
                    double newBalance = Withdraw(balance, withdrawAmount);
                    if (newBalance != balance)
                    {
                        balance = newBalance;
                        Console.WriteLine("Withdrawal successful.\n");
                    }
                    break;

                case 4:
                    keepRunning = false;
                    Console.WriteLine("Thank you for using the Simple Banking App!");
                    break;
            }
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("Simple Banking App");
        Console.WriteLine("-------------------");
        Console.WriteLine("1. View Balance");
        Console.WriteLine("2. Deposit Funds");
        Console.WriteLine("3. Withdraw Funds");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1–4): ");

        string input = Console.ReadLine();
        int choice;

        if (int.TryParse(input, out choice))
        {
            return choice;
        }
        else
        {
            return -1; // Invalid input
        }
    }

    static void ShowBalance(double balance)
    {
        Console.WriteLine($"Current Balance: ${Math.Round(balance, 2)}");
        Console.WriteLine();
    }

    static double GetTransactionAmount(string type)
    {
        Console.Write($"Enter amount to {type.ToLower()}: ");
        string input = Console.ReadLine();
        double amount;

        while (!double.TryParse(input, out amount) || amount <= 0)
        {
            Console.Write("Invalid input. Please enter a positive numeric value: ");
            input = Console.ReadLine();
        }

        return amount;
    }

    static double Deposit(double balance, double amount)
    {
        return balance + amount;
    }

    static double Withdraw(double balance, double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Error: Insufficient funds.");
            Console.WriteLine();
            return balance;
        }

        return balance - amount;
    }
}