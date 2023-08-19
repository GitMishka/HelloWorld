using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Sum: {num1 + num2}");
            Console.WriteLine($"Difference: {num1 - num2}");
            Console.WriteLine($"Product: {num1 * num2}");
            if (num2 != 0) // To avoid division by zero
            {
                Console.WriteLine($"Quotient: {num1 / num2}");
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }

        }
    }
}
