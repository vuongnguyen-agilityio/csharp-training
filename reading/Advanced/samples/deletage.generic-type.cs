using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.samples
{
    internal class DeletageGenericType
    {
        // Declare a delegate
        public delegate T Callback<T>();

        public class SampleClass
        {
            public void InstanceMethodVoid()
            {
                Console.WriteLine("A message from the instance method void.");
            }

            public object InstanceMethodObjectNull()
            {
                Console.WriteLine("A message from the instance method object null.");
                return null;
            }

            public bool InstanceMethodBool()
            {
                Console.WriteLine("A message from the instance method bool.");
                return true;
            }

            // return object:null instead void can avoid the generic type not allow void

            public static object StaticMethod()
            {
                Console.WriteLine("A message from the static method.");
                return null;
            }
        }

        public void RunTest()
        {
            // What Sample Do?
            // 1. Create sample delegate with generic type
            // 2. Call Instance method using generic type
            // 3. Call Static method
            var sc = new SampleClass();

            // Callback<void> d = sc.InstanceMethodVoid; // <== this callback will not work because void is not a type.
            Callback<object> d = sc.InstanceMethodObjectNull;
            Callback<bool> a = sc.InstanceMethodBool;
            d();

            // Map to the static method:
            d = SampleClass.StaticMethod;
            d();
        }

    }
}
