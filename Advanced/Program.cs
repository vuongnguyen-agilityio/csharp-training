using Advanced.samples.BookTestClient;
using static Advanced.samples.DelegateSample;
using static Advanced.samples.DeletageGenericType;

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


            // Do Sample with generic type
            var sc = new SampleClass();

            // Map the delegate to the instance method:
            // Callback<void> d = sc.InstanceMethodVoid; // <== this callback will not work because void is not a type.
            Callback<object> d = sc.InstanceMethodObjectNull;
            Callback<bool> a = sc.InstanceMethodBool;
            d();

            // Map to the static method:
            d = SampleClass.StaticMethod;
            d();

            // Do Sample with a bookstore
            TestBookDB.RunTest();
        }
    }
}