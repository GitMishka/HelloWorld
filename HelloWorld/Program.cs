using System;

Random rand = new();
int secretNumber = rand.Next(1, 101); // Random number between 1 and 100

Console.WriteLine("Guess the number between 1 and 100!");

int guess;
do
{
    Console.Write("Enter your guess: ");
    guess = Convert.ToInt32(Console.ReadLine());

    if (guess > secretNumber)
    {
        Console.WriteLine("Too high!");
    }
    else if (guess < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
    else
    {
        Console.WriteLine("Congratulations! You guessed the correct number!");
    }
} while (guess != secretNumber);
