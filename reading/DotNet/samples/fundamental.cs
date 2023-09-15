using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.samples
{
    internal class Fundamental
    {
        public void RunTest()
        {
            // String
            char[] ca = "Hello".ToCharArray();
            string s = new string(ca); // s = "Hello"

            // Null and Empty Strings
            string empty = "";
            Console.WriteLine(empty == ""); // True
            Console.WriteLine(empty == string.Empty); // True
            Console.WriteLine(empty.Length == 0); // True

            string? nullString = null;
            Console.WriteLine(nullString == null); // True
            Console.WriteLine(nullString == ""); // False
            Console.WriteLine(nullString?.Length == 0); // NullReferenceException

            // String.Format
            string composite = "It's {0} degrees in {1} on this {2} morning";
            string str = string.Format(composite, 35, "Perth", DateTime.Now.DayOfWeek);
            // str == "It's 35 degrees in Perth on this Friday morning"
            string str1 = $"It's hot this {DateTime.Now.DayOfWeek} morning";

            // Formatting and Parsing
            // ToString and Parse
            string str2 = true.ToString(); // s = "True"
            bool b = bool.Parse(str2); // b = true

            // Composite Formatting
            string composite1 = "Credit={0:C}"; // C is currency
            Console.WriteLine(string.Format(composite1, 500)); // Credit=$500.00
        }
    }
}
