using System;

namespace CSharpBasicsAndOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output
            Console.WriteLine("Welcome to the C# Basics and OOP Demo!");

            // Variables and Data Types
            int myNumber = 42;
            double myDouble = 3.14;
            string myString = "Hello, World!";
            bool myBool = true;

            // Comments
            // This is a single-line comment
            /*
             * This is a multi-line comment
             */

            // Operators
            int x = 10;
            int y = 5;
            string name = "Alice";
            bool isStudent = true;

            // Combine various operators
            int result = (x + y) * 2 % 3; // Arithmetic, assignment (=) implied
            bool isAdult = (x >= 18) && !isStudent; // Comparison, logical (&&, !)
            string greeting = $"Hello, {name}! Your age is {(x + 3) - y}."; // String concatenation (+), conditional expression ()

            Console.WriteLine($"Result: {result}"); // Output using string interpolation
            Console.WriteLine($"Is Adult: {isAdult}");
            Console.WriteLine(greeting);

            // Math Library
            double pi = Math.PI; // Get the value of pi
            double squareRoot = Math.Sqrt(16); // Calculate square root
            double power = Math.Pow(2, 3); // Calculate power (2 raised to the power of 3)
            double absoluteValue = Math.Abs(-7.5); // Get absolute value

           
            Console.WriteLine("Pi: " +pi); // another to concatanate strings with the variables
            Console.WriteLine($"Square root of 16: {squareRoot}");
            Console.WriteLine($"2 raised to the power of 3: {power}");
            Console.WriteLine($"Absolute value of -7.5: {absoluteValue}");

            // Strings and switch case
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Strings Menu");
                Console.WriteLine("1. Concatenation");
                Console.WriteLine("2. Interpolation");
                Console.WriteLine("3. Access Strings");
                Console.WriteLine("4. Special Characters");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter a string:");
                        string string1 = Console.ReadLine();
                        Console.WriteLine("Enter another string:");
                        string string2 = Console.ReadLine();
                        string concatenatedString = string1 + string2;
                        Console.WriteLine($"Concatenated string: {concatenatedString}");
                        break;
                    case "2":
                        Console.WriteLine("Enter your name:");
                        string nam = Console.ReadLine();
                        int ages = 25; // Hypothetical age
                        string greetings = $"Hello, {nam}! You are {ages} years old.";
                        Console.WriteLine(greetings);
                        break;
                    case "3":
                        Console.WriteLine("Enter a string:");
                        string inputString = Console.ReadLine();
                        if (inputString.Length > 0)
                        {
                            Console.WriteLine($"First character: {inputString[0]}");
                            int lastIndex = inputString.Length - 1;
                            Console.WriteLine($"Last character: {inputString[lastIndex]}");
                        }
                        else
                        {
                            Console.WriteLine("Empty string.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Special characters:");
                        Console.WriteLine("\\n - New line");
                        Console.WriteLine("\\t - Horizontal tab");
                        Console.WriteLine("\\\" - Double quote");
                        break;
                    case "5":
                        continueProgram = false;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

                // Booleans
                bool isGreater = myNumber > 10;

            // Conditional Statements
            if (isGreater)
            {
                Console.WriteLine($"{myNumber} is greater than 10");
            }
            else
            {
                Console.WriteLine($"{myNumber} is not greater than 10");
            }

            // Loops
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Loop iteration: {i}");
            }

            // Arrays
            // Array declaration
            int[] numbers = new int[5]; // Array to store 5 integers

            // Get user input for array elements
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter number {i + 1}:");
                string inputNumber = Console.ReadLine();

                // Input validation (assuming integers)
                int number;
                if (int.TryParse(inputNumber, out number))
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    i--; // Decrement i to repeat input for the same index
                }
            }

            // Display original array
            Console.WriteLine("Original array:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            // Sorting the array (ascending order)
            Array.Sort(numbers);

            // Display sorted array
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();

            // Functions/Methods
            int results = Add(5, 7);
            Console.WriteLine($"Sum of 5 and 7 is: {result}");

            // Object-Oriented Programming
            Person person = new Person("John", 30);
            Console.WriteLine(person.Introduce());

            // User Input
            Console.Write("Enter your age: ");
            string input = Console.ReadLine();
            int age = int.Parse(input);

            Console.WriteLine($"You are {age} years old.");

            // Type Casting
            int myInt = 10;
            double myDoubles = 5.25;
            bool myBools = true;

            Console.WriteLine(Convert.ToString(myInt));    // convert int to string
            Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
            Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
            Console.WriteLine(Convert.ToString(myBool));   // convert bool to string

            static int Add(int a, int b)
            {
                return a + b;
            }
        }

        // Principles of OOP
        // Class Definition
        class Person
        {
            // Properties
            public string Name { get; set; }
            public int Age { get; set; }

            // Constructor
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            // Method
            public string Introduce()
            {
                return $"Hello, my name is {Name} and I am {Age} years old.";
            }
        }
    }
}
