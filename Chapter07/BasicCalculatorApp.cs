using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            int choice = DisplayMenu();

            if (choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid selection. Please enter a number between 1 and 5.\n");
                continue;
            }

            if (choice == 5)
            {
                keepRunning = false;
                Console.WriteLine("Thank you for using the calculator!");
                break;
            }

            double num1 = GetNumberInput("Enter the first number: ");
            double num2 = GetNumberInput("Enter the second number: ");
            double result = 0;
            string opSymbol = "";

            switch (choice)
            {
                case 1:
                    result = Add(num1, num2);
                    opSymbol = "+";
                    break;
                case 2:
                    result = Subtract(num1, num2);
                    opSymbol = "-";
                    break;
                case 3:
                    result = Multiply(num1, num2);
                    opSymbol = "*";
                    break;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.\n");
                        continue;
                    }
                    result = Divide(num1, num2);
                    opSymbol = "/";
                    break;
            }

            DisplayResult(num1, num2, result, opSymbol);
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("Basic Calculator");
        Console.WriteLine("-----------------");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1–5): ");

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

    static double GetNumberInput(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        double number;

        while (!double.TryParse(input, out number))
        {
            Console.Write("Invalid input. Please enter a numeric value: ");
            input = Console.ReadLine();
        }

        return number;
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return double.NaN;
        }

        return a / b;
    }

    static void DisplayResult(double a, double b, double result, string operation)
    {
        Console.WriteLine($"{a} {operation} {b} = {Math.Round(result, 2)}");
        Console.WriteLine();
    }
}