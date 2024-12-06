using System.Text.RegularExpressions;

class Calculator
{
    public static double DoOperation(double num1, double num2, string operation)
    {
        double result = double.NaN;
        switch (operation)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        
        Console.WriteLine($"--- Console Calculator ---\r");
        Console.WriteLine("---------------------------\n");

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;
            
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum = 0;
            while (!double.TryParse(numInput1, out cleanNum))
            {
                Console.Write("Invalid number, please try again: ");
                numInput1 = Console.ReadLine();
            }
            
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();
            
            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Invalid number, please try again: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
            
            string? operation = Console.ReadLine();

            if (operation == null || !Regex.IsMatch(operation, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized operator.");
            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(cleanNum, cleanNum2, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                } catch (Exception e) {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }

            Console.WriteLine("---------------------------\n");
            
            Console.Write("Press 'n' and Enter to close the app, or press any key and Enter to continue");
            if (Console.ReadLine() == "n")
            {
                endApp = true;
            }

            Console.WriteLine("\n");
        }

        return;
    }
}