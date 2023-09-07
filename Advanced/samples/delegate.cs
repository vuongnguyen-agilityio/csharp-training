using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.samples
{
    internal class Delegate
    {
        // What Sample Do?
        // 1. Create sample delegate
        // 2. Assign methods to delegate
        // 3. Unassign methods from delegate

        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine("DelegateMethod: " + message);
        }

        public class MethodClass
        {
            public void Method1(string message)
            {
                Console.WriteLine("Method 1: " + message);
            }
            public void Method2(string message)
            {
                Console.WriteLine("Method 2: " + message);
            }
        }

        public delegate void Callback(string message);
    }
}
