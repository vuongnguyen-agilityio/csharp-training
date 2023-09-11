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
    }
}
