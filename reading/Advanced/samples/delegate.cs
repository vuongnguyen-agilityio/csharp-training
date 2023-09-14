using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.samples
{
    internal class DelegateSample
    {
        // What Sample Do?
        // 1. Create sample delegate
        // 2. Assign methods to delegate
        // 3. UnAssign methods from delegate

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

        delegate void Callback(string message);

        public void RunTest()
        {
            var obj = new MethodClass();
            Callback d1 = obj.Method1;
            Callback d2 = obj.Method2;
            Callback d3 = DelegateMethod;

            //Both types of assignment are valid.
            Callback allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;

            allMethodsDelegate("Hello World!");

            allMethodsDelegate -= d2;

            allMethodsDelegate("Hello World!");
        }
    }
}
