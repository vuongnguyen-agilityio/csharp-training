using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.IO;

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
            
            // Print results
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

            // Print results
            Console.Write("Number" + "\t" + "Number*Frequency" + "\t" + "Frequency" + "\n");
            Console.Write("------------------------------------------------\n");
            res.ToList().ForEach(item => Console.WriteLine($"{item.Number}\t{item.Multiplication}\t\t\t{item.Frequency}"));
        }

        /* TODO:
         * 8. Write a program in C# Sharp to find the string which starts and ends with a specific character
         * Input :
         * The cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
         * Input starting character for the string : A
         * Input ending character for the string : M
         * 
         * Expected Output :
         * The city starting with A and ending with M is : AMSTERDAM
         */
        string[] FindString(string[] strs, char StartWith, char EndWith)
        {
            string[] matchedStrings = strs.Where(str => str.StartsWith(StartWith) && str.EndsWith(EndWith)).ToArray();

            // Print results
            matchedStrings.ToList().ForEach(str => Console.Write(str + " "));
            
            return matchedStrings;
        }

        /*
         * 9. Write a program in C# Sharp to create a list of numbers and display the numbers greater than 80 as output
         * Input :
         * 55 200 740 76 230 482 95
         * 
         * Expected Output :
         * The numbers greater than 80 are :
         * 200
         * 740
         * 230
         * 482
         * 95
         */
        IEnumerable<int> FindGreaterNumber(int[] numbers, int compareNumber)
        {
            IEnumerable<int> res = numbers.Where(num => num >= compareNumber);

            // Print results
            res.ToList().ForEach(str => Console.Write(str + " "));

            return res;
        }

        /*
         * TODO: Upgrade this function to accept the input data from console
         * 
         * 10. Write a program in C# Sharp to Accept the members of a list through the keyboard and display the members more than a specific value
         * Input the number of members on the List : 5
         * Member 0 : 10
         * Member 1 : 48
         * Member 2 : 52
         * Member 3 : 94
         * Member 4 : 63
         * Input the value above you want to display the members of the List : 59
         * 
         * Expected Output :
         * The numbers greater than 59 are :
         * 94
         * 63
         */
        IEnumerable<int> FindGreaterNumberFromInput(int[] numbers, int compareNumber)
        {
            return FindGreaterNumber(numbers, compareNumber);
        }

        /*
         * 11. Write a program in C# Sharp to display the top n-th records
         * Test Data :
         * The members of the list are :
         * { 5, 7, 13, 24, 6, 9, 8, 7 }
         * How many records you want to display ? : 3
         * Expected Output :
         * The top 3 records from the list are :
         * 24
         * 13
         * 9
         */
        IEnumerable<int> FindTopOfNumbers(int[] numbers, int topNumber)
        {
            IEnumerable<int> res = numbers.OrderByDescending(num => num).Take(topNumber);

            // Print results
            res.ToList().ForEach(num => Console.Write(num + " "));

            return res;
        }

        /*
         * 12. Write a program in C# Sharp to find the uppercase words in a string
         * Test Data :
         * Input the string : this IS a STRING
         * Expected Output :
         * The UPPER CASE words are :
         * IS
         * STRING
         */
        IEnumerable<string> FindUpperCaseWords(string str)
        {
            IEnumerable<string> res = str.Split().Where(word => word == word.ToUpper());

            // Print results
            res.ToList().ForEach(word => Console.Write(word + " "));

            return res;
        }

        /*
         * 13. Write a program in C# Sharp to convert a string array to a string
         * Test Data :
         * Input number of strings to store in the array :3
         * Input 3 strings for the array :
         * Element[0] : cat
         * Element[1] : dog
         * Element[2] : rat
         * Expected Output:
         * Here is the string below created with elements of the above array :
         * cat, dog, rat
         */
        string ConvertStringArrayToString(string[] strs)
        {
            string res = string.Join(", ", strs);
            
            // Print results
            Console.Write(res);

            return res;
        }

        /*
         * 14. Write a program in C# Sharp to find the n-th Maximum grade point achieved by the students from the list of students
         * Test Data :
         * StuId = 1, StuName = " Joseph ", GrPoint = 800
         * StuId = 2, StuName = "Alex", GrPoint = 458
         * StuId = 3, StuName = "Harris", GrPoint = 900
         * StuId = 4, StuName = "Taylor", GrPoint = 900
         * StuId = 5, StuName = "Smith", GrPoint = 458
         * StuId = 6, StuName = "Natasa", GrPoint = 700
         * StuId = 7, StuName = "David", GrPoint = 750
         * StuId = 8, StuName = "Harry", GrPoint = 700
         * StuId = 9, StuName = "Nicolash", GrPoint = 597
         * StuId = 10, StuName = "Jenny", GrPoint = 750
         * 
         * Which maximum grade point(1st, 2nd, 3rd, ...) you want to find: 3
         * Expected Output:
         * Id : 7, Name : David, achieved Grade Point : 750
         * Id : 10, Name : Jenny, achieved Grade Point : 750
         */

        dynamic[] FindMaximumGradePoint(dynamic[] students, int NthGradePoint = 0)
        {
            dynamic[] res = students.GroupBy(student => student.GrPoint).OrderByDescending(student => student.ElementAt(0).GrPoint).ElementAt(NthGradePoint).ToArray();

            // Print results
            res.ToList().ForEach(student => Console.WriteLine($"Id: {student.StuId}, Name: {student.StuName}, GrPoint: {student.GrPoint}"));

            return res;
        }

        /*
         * 15. Write a program in C# Program to Count File Extensions and Group it using LINQ
         * Test Data :
         * The files are : aaa.frx, bbb.TXT, xyz.dbf,abc.pdf
         * aaaa.PDF,xyz.frt, abc.xml, ccc.txt, zzz.txt
         * 
         * Expected Output :
         * Here is the group of extension of the files :
         * 1 File(s) with .frx Extension
         * 3 File(s) with .txt Extension
         * 1 File(s) with .dbf Extension
         * 2 File(s) with .pdf Extension
         * 1 File(s) with .frt Extension
         * 1 File(s) with .xml Extension
         */
        dynamic[] CountFileExtensions(string[] fileNames) {
            dynamic[] res = fileNames.GroupBy(fileName => fileName.Split(".").ElementAt(1).ToLower())
                .Select(groupedFileNames => new {
                    Extension = groupedFileNames.ElementAt(0).Split(".").ElementAt(1).ToLower(),
                    Counter = groupedFileNames.Count(),
                }).ToArray();

            // Print results
            res.ToList().ForEach(file => {
                Console.WriteLine($"{file.Counter} File(s) with {file.Extension}");
            });

            return res;
        }

        /*
         * 16. Write a program in C# Sharp to Calculate Size of File linq-30-exercises.cs using LINQ
         * 
         * Expected Output :
         * The Average file size is X.X KB
         */
        long CalcFileSize(string filePath)
        {
            long res = new FileInfo(filePath).Length;
            Console.WriteLine($"The Average file size is {Math.Round((Decimal)res/1024, 2)} KB");
            return res;
        }

        void RemoveCharInList()
        {
            /*
             * 17. Write a program in C# Sharp to Remove Items from List using remove function by passing the object
             * Test Data :
             * Here is the list of items :
             * Char: m
             * Char: n
             * Char: o
             * Char: p
             * Char: q
             * Expected Output:
             * Here is the list after removing the item 'o' from the list :
             * Char: m
             * Char: n
             * Char: p
             * Char: q
             */
            List<char> ListChars = new List<char> { 'm', 'n', 'o', 'p', 'q' };
            ListChars.Remove('o');
            // Print results
            ListChars.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();

            /*
             * 18. Write a program in C# Sharp to Remove Items from List by creating an object internally by filtering
             * Test Data :
             * Here is the list of items :
             * Char: m
             * Char: n
             * Char: o
             * Char: p
             * Char: q
             * 
             * Expected Output :
             * Here is the list after removing the item 'p' from the list :
             * Char: m
             * Char: n
             * Char: o
             * Char: q
             */
            List<char> ListChars02 = new List<char> { 'm', 'n', 'o', 'p', 'q' };
            ListChars02.Remove(ListChars02.FirstOrDefault('p'));
            // Print results
            ListChars02.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();

            /*
             * 19. Write a program in C# Sharp to Remove Items from List by passing filters. Go to the editor
             * Test Data :
             * Here is the list of items :
             * Char: m
             * Char: n
             * Char: o
             * Char: p
             * Char: q
             * Expected Output :
             * Here is the list after removing item 'q' from the list :
             * Char: m
             * Char: n
             * Char: o
             * Char: p
             */
            List<char> ListChars03 = new List<char> { 'm', 'n', 'o', 'p', 'q', 'p' };
            ListChars03.RemoveAll(item => item == 'p');
            // Print results
            ListChars03.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();

            /*
             * 21. Write a program in C# Sharp to remove a range of items from a list by passing the start index and number of elements to remove.
             * Test Data :
             * Here is the list of items :
             * Char: m
             * Char: n
             * Char: o
             * Char: p
             * Char: q
             * Expected Output :
             * Here is the list after removing item 'q' from the list :
             * Char: m
             * Char: q
             */
            List<char> ListChars04 = new List<char> { 'm', 'n', 'o', 'p', 'q'};
            ListChars04.RemoveRange(1, 3);
            // Print results
            ListChars04.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();
        }

        /*
         * Duplicated with #3
         * 20. Find the number and its square of an array which is more than 20
         */


        /*
         * TODO:
         * 22. Write a program in C# Sharp to find the strings for a specific minimum length
         * 
         * Test Data :
         * Input number of strings to store in the array :4
         * Input 4 strings for the array:
         * Element[0] : this
         * Element[1] : is
         * Element[2] : a
         * Element[3] : string
         * Input the minimum length of the item you want to find : 5
         * 
         * Expected Output:
         * The items of minimum 5 characters are :
         * Item: string
         */

        public void RunTest()
        {
            Console.WriteLine("1. Start ListDividedByTwos: ");
            ListDividedByTwos(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine();

            Console.WriteLine("2. Start ListPositives: ");
            ListPositives(new int[] { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 });
            Console.WriteLine();

            Console.WriteLine("3. Start ListSquares: ");
            ListSquares(new int[] { 3, 9, 2, 8, 6, 5 });
            Console.WriteLine();

            Console.WriteLine("4. Start CountRepeatNumberInArray: ");
            CountRepeatNumberInArray(new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 });
            Console.WriteLine();

            Console.WriteLine("5. Start CountRepeatCharracterinString: ");
            CountRepeatCharracterinString("apple");
            Console.WriteLine();

            Console.WriteLine("6. Start PrintDaysOfWeek: ");
            PrintDaysOfWeek();
            Console.WriteLine();

            Console.WriteLine("7. Start PrintFrequency: ");
            PrintFrequency(new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 });
            Console.WriteLine();

            Console.WriteLine("8. Start FindString: ");
            FindString(new string[] { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" }, 'A', 'M');
            Console.WriteLine();

            Console.WriteLine("9. Start FindGreaterNumber: ");
            FindGreaterNumber(new int[] { 55, 200, 740, 76, 230, 482, 95 }, 80);
            Console.WriteLine();

            Console.WriteLine("10. Start FindGreaterNumberFromInput: ");
            FindGreaterNumberFromInput(new int[] { 10, 48, 52, 94, 63 }, 59);
            Console.WriteLine();

            Console.WriteLine("11. Start FindTopOfNumbers: ");
            FindTopOfNumbers(new int[] { 5, 7, 13, 24, 6, 9, 8, 7 }, 3);
            Console.WriteLine();

            Console.WriteLine("12. Start FindUpperCaseWords: ");
            FindUpperCaseWords("this IS a STRING");
            Console.WriteLine();

            Console.WriteLine("13. Start ConvertStringArrayToString: ");
            ConvertStringArrayToString(new string[] { "cat", "dog", "rat" });
            Console.WriteLine();

            Console.WriteLine("14. Start FindMaximumGradePoint: ");
            FindMaximumGradePoint(new dynamic[] {
            new { StuId = 1, StuName = "Joseph", GrPoint = 800  },
            new { StuId = 2, StuName = "Alex", GrPoint = 458 },
            new { StuId = 3, StuName = "Harris", GrPoint = 900 },
            new { StuId = 4, StuName = "Taylor", GrPoint = 900 },
            new { StuId = 5, StuName = "Smith", GrPoint = 458 },
            new { StuId = 6, StuName = "Natasa", GrPoint = 700 },
            new { StuId = 7, StuName = "David", GrPoint = 750 },
            new { StuId = 8, StuName = "Harry", GrPoint = 700 },
            new { StuId = 9, StuName = "Nicolash", GrPoint = 597 },
            new { StuId = 10, StuName = "Jenny", GrPoint = 750 },
            }, 3);
            Console.WriteLine();

            Console.WriteLine("15. Start CountFileExtensions: ");
            CountFileExtensions(new string[] { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" });
            Console.WriteLine();

            Console.WriteLine("16. Start CalcFileSize: ");
            CalcFileSize($"{Directory.GetCurrentDirectory().Replace("bin\\Debug\\net7.0", "exercises\\linq-30-exercises.cs")}");
            Console.WriteLine();

            Console.WriteLine("17. Start RemoveCharInList: ");
            RemoveCharInList();
            Console.WriteLine();
        }
    }
}
