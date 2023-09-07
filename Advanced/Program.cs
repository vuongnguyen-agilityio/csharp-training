using static Advanced.samples.Delegate;

namespace Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // What Sample Do?
            // 1. Create sample delegate
            // 2. Assign methods to delegate
            // 3. Unassign methods from delegate
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