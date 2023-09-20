using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DotNet.exercises
{
    internal class LINQ30Exercises
    {
        /*
         * 1. Write a program in C# Sharp to shows how the three parts of a query operation execute
         * Input:
         * int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
         * 
         * Expected Output:
         * The numbers which produce the remainder 0 after divided by 2 are :
         * 0 2 4 6 8
         */
        int[] ListDividedByTwos(int[] numbers, int dividedBy = 2)
        {
            int[] res = numbers.Where(num => num % dividedBy == 0).ToArray();

            // Print results
            res.ToList().ForEach(num => Console.Write(num + " "));

            return res;
        }

        /*
         * 2. Write a program in C# Sharp to find the positive numbers from a list of numbers using two where conditions in LINQ Query
         * 
         * Input:
         * int[] n1 = {  1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14  };
         * 
         * Expected Output:
         * The numbers within the range of 1 to 11 are :
         * 1 3 6 9 10
         */
        int[] ListPositives(int[] numbers)
        {
            int min = 1;
            int max = 11;
            int[] res = numbers.Where(num => min <= num && num < max).ToArray();

            // Print results
            res.ToList().ForEach(num => Console.Write(num + " "));

            return res;
        }

        /*
         * 3. Write a program in C# Sharp to find the number of an array and the square of each number which is more than 20
         * Input:
         * new[] { 3, 9, 2, 8, 6, 5 }
         * 
         * Expected Output :
         * { Number = 9, SqrNo = 81 }
         * { Number = 8, SqrNo = 64 }
         * { Number = 6, SqrNo = 36 }
         * { Number = 5, SqrNo = 25 }
         */
        interface ISquare { int Number { get; } };
        class Square : ISquare
        {
            public Square(int number)
            {
                Number = number;
            }
            public int Number { get; }
            public int SqrNo => Number * Number;
        }
        Square[] ListSquares(int[] numbers)
        {
            int maxSqr = 20;
            Square[] res = numbers.Where(num => num * num > maxSqr).Select(num => new Square(num)).ToArray();

            // Print results
            res.ToList().ForEach(square => Console.WriteLine(JsonSerializer.Serialize(square)));

            return res;
        }

        /*
         * 4. Write a program in C# Sharp to display the number and frequency of number from giving array
         * Input:
         * new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 }
         * 
         * Expected Output :
         * The number and the Frequency are :
         * Number 5 appears 3 times
         * Number 9 appears 2 times
         * Number 1 appears 1 times
         */
        dynamic[] CountRepeatNumberInArray(int[] numbers)
        {
            dynamic[] res = numbers.GroupBy(num => num).Select(repeatNumbers => new { num = repeatNumbers.ElementAt(0), repeatCounter = repeatNumbers.Count() }).ToArray();
            
            // Print results
            res.ToList().ForEach(repeatCounter => Console.WriteLine(JsonSerializer.Serialize(repeatCounter)));

            return res;
        }

        /*
         * 5. Write a program in C# Sharp to display the characters and frequency of character from giving string
         * Input:
         * apple
         * 
         * Expected Output:
         * The frequency of the characters are :
         * Character a: 1 times
         * Character p: 2 times
         * Character l: 1 times
         * Character e: 1 times
         */
        dynamic[] CountRepeatCharracterinString(string str)
        {
            dynamic[] res = str.ToCharArray().GroupBy(charracter => charracter).Select(repeatChars => new { charracter = repeatChars.ElementAt(0), repeatCounter = repeatChars.Count() }).ToArray();
            
            // Print results
            res.ToList().ForEach(repeatChars => Console.WriteLine(JsonSerializer.Serialize(repeatChars)));

            return res;
        }

        /*
         * 6. Write a program in C# Sharp to display the name of the days of a week
         * Input:
         * string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
         * 
         * Expected Output:
         * Sunday
         * Monday
         * Tuesday
         * Wednesday
         * Thursday
         * Friday
         * Saturday
         */
        void PrintDaysOfWeek()
        {
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            dayWeek.ToList().ForEach(day => Console.Write(day + ", "));
        }

        /*
         * 7. Write a program in C# Sharp to display numbers, multiplication of number with frequency and frequency of a number of giving array
         * Test Data :
         * The numbers in the array are :
         * 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2
         * Expected Output As Table:
         * Number | Number * Frequency | Frequency
         */
        void PrintFrequency(int[] numbers)
        {
            dynamic[] res = numbers.GroupBy(num => num).Select(repeatNums => {
                int Number = repeatNums.ElementAt(0);
                int Frequency = repeatNums.Count();
                return new { Number, Multiplication = Number * Frequency, Frequency };
            }).ToArray();
            Console.Write("Number" + "\t" + "Number*Frequency" + "\t" + "Frequency" + "\n");
            Console.Write("------------------------------------------------\n");
            res.ToList().ForEach(item => Console.WriteLine($"{item.Number}\t{item.Multiplication}\t\t\t{item.Frequency}"));
        }

        /* TODO:
         * 8. Write a program in C# Sharp to find the string which starts and ends with a specific character. Go to the editor
         * Test Data :
         * The cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
         * Input starting character for the string : A
         * Input ending character for the string : M
         * Expected Output :
         * The city starting with A and ending with M is : AMSTERDAM
         * Click me to see the solution
         */

        public void RunTest()
        {
            Console.WriteLine("Start ListDividedByTwos: ");
            ListDividedByTwos(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine();

            Console.WriteLine("Start ListPositives: ");
            ListPositives(new int[] { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 });
            Console.WriteLine();

            Console.WriteLine("Start ListSquares: ");
            ListSquares(new int[] { 3, 9, 2, 8, 6, 5 });
            Console.WriteLine();

            Console.WriteLine("Start CountRepeatNumberInArray: ");
            CountRepeatNumberInArray(new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 });
            Console.WriteLine();

            Console.WriteLine("Start CountRepeatCharracterinString: ");
            CountRepeatCharracterinString("apple");
            Console.WriteLine();

            Console.WriteLine("Start PrintDaysOfWeek: ");
            PrintDaysOfWeek();
            Console.WriteLine();

            Console.WriteLine("Start PrintFrequency: ");
            PrintFrequency(new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 });
            Console.WriteLine();

        }
    }
}
