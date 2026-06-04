using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            int choice = DisplayMenu();

            switch (choice)
            {
                case 1:
                    double celsius = GetTemperatureInput("Celsius");
                    double fahrenheit = ConvertCtoF(celsius);
                    DisplayResult(celsius, fahrenheit, "Celsius", "Fahrenheit");
                    break;

                case 2:
                    fahrenheit = GetTemperatureInput("Fahrenheit");
                    celsius = ConvertFtoC(fahrenheit);
                    DisplayResult(fahrenheit, celsius, "Fahrenheit", "Celsius");
                    break;

                case 3:
                    keepRunning = false;
                    Console.WriteLine("Thank you for using the Temperature Converter!");
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.
");
                    break;
            }
        }
    }

    static int DisplayMenu()
    {
        Console.WriteLine("Temperature Converter");
        Console.WriteLine("----------------------");
        Console.WriteLine("1. Convert Celsius to Fahrenheit");
        Console.WriteLine("2. Convert Fahrenheit to Celsius");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice (1–3): ");

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

    static double GetTemperatureInput(string scale)
    {
        Console.Write($"Enter temperature in {scale}: ");
        string input = Console.ReadLine();
        double temperature;

        while (!double.TryParse(input, out temperature))
        {
            Console.Write("Invalid input. Please enter a numeric value: ");
            input = Console.ReadLine();
        }

        return temperature;
    }

    static double ConvertCtoF(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double ConvertFtoC(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static void DisplayResult(double original, double converted, string fromScale, string toScale)
    {
        Console.WriteLine($"{original} degrees {fromScale} is {Math.Round(converted, 1)} degrees {toScale}.");
        Console.WriteLine();
    }
}