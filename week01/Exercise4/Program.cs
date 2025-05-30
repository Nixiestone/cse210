using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
                break;

            numbers.Add(number);
        }

        // Compute the sum of numbers
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
                max = num;
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
                smallestPositive = num;
        }
        if (smallestPositive != int.MaxValue)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("Thanks for using the Exercise4 Project!");
    }
}