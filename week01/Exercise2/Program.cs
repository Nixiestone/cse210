using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
    {
        Console.WriteLine("Welcome to the Grade Calculator!");
        // Core Requirement 1: Get grade percentage from user
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        // Core Requirement 3: Determine letter grade using a variable
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement 2: Check if passed
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! You can try again next time.");
        }

        // Stretch Challenge: Determine + or - sign
        string sign = "";
        int lastDigit = gradePercentage % 10;

        // Only apply signs for B, C, D grades
        if (letter == "B" || letter == "C" || letter == "D")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // Special case for A (no A+)
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-";
        }
        // F always has no sign
        else if (letter == "F")
        {
            sign = "";
        }

        // Print the final grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
    }

        }
    
}