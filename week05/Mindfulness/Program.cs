using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    abstract class MindfulnessActivity
    {
        protected string ActivityName;
        protected string Description;
        protected int Duration;

        public virtual void StartActivity()
        {
            Console.WriteLine($"Starting {ActivityName}...");
            Console.WriteLine(Description);
            Console.Write("Enter duration in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Pause(3);
        }

        public virtual void EndActivity()
        {
            Console.WriteLine($"Good job! You have completed the {ActivityName} for {Duration} seconds.");
            Pause(3);
        }

        protected void Pause(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public abstract void PerformActivity();
    }

    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
        {
            ActivityName = "Breathing Activity";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            int cycles = Duration / 6;

            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("Breathe in...");
                Pause(3);
                Console.WriteLine("Breathe out...");
                Pause(3);
            }

            EndActivity();
        }
    }

    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random random = new Random();

        public ReflectionActivity()
        {
            ActivityName = "Reflection Activity";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
            int totalQuestions = Duration / 7;

            for (int i = 0; i < totalQuestions; i++)
            {
                Console.WriteLine(Questions[random.Next(Questions.Count)]);
                Pause(5);
            }

            EndActivity();
        }
    }

    class ListingActivity : MindfulnessActivity
    {
        private List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt joy this month?",
            "Who are some of your personal heroes?"
        };

        private Random random = new Random();

        public ListingActivity()
        {
            ActivityName = "Listing Activity";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void PerformActivity()
        {
            StartActivity();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
            Pause(3);

            Console.WriteLine("Start listing items. Type 'done' to finish:");
            List<string> items = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                items.Add(input);
            }

            Console.WriteLine($"You listed {items.Count} items.");
            EndActivity();
        }
    }

    static class QuoteGenerator
    {
        private static List<string> Quotes = new List<string>
        {
            "Peace begins with a smile. – Mother Teresa",
            "Breathe. Let go. And remind yourself that this very moment is the only one you know you have for sure. – Oprah Winfrey",
            "Mindfulness isn’t difficult, we just need to remember to do it. – Sharon Salzberg",
            "You should sit in meditation for 20 minutes a day — unless you’re too busy. Then you should sit for an hour. – Zen proverb"
        };

        public static void ShowRandomQuote()
        {
            Random rand = new Random();
            Console.WriteLine("\n🧘‍♀️ Daily Mindfulness Quote:");
            Console.WriteLine($"\"{Quotes[rand.Next(Quotes.Count)]}\"\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 📝 Creative Enhancement:
            // I added a "Daily Quote" feature that displays a random mindfulness quote after each activity.
            // This adds motivation and inspiration to the user experience.

            while (true)
            {
                Console.WriteLine("\nChoose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        continue;
                }

                activity.PerformActivity();
                QuoteGenerator.ShowRandomQuote(); // Show daily quote after activity
            }
        }
    }
}