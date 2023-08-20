using System;

Console.WriteLine("Temperature Converter");
Console.WriteLine("1. Celsius to Fahrenheit");
Console.WriteLine("2. Fahrenheit to Celsius");
Console.Write("Choose your option (1/2): ");
int option = int.Parse(Console.ReadLine());

Console.Write("Enter the temperature value: ");
double temp = double.Parse(Console.ReadLine());
double convertedTemp;

switch (option)
{
    case 1:
        convertedTemp = CelsiusToFahrenheit(temp);
        Console.WriteLine($"{temp}°C is equivalent to {convertedTemp}°F");
        break;
    case 2:
        convertedTemp = FahrenheitToCelsius(temp);
        Console.WriteLine($"{temp}°F is equivalent to {convertedTemp}°C");
        break;
    default:
        Console.WriteLine("Invalid option chosen.");
        break;
}

double CelsiusToFahrenheit(double celsius)
{
    return (celsius * 9 / 5) + 32;
}

double FahrenheitToCelsius(double fahrenheit)
{
    return (fahrenheit - 32) * 5 / 9;
}
