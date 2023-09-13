using System.Text;

public class StringBuilderExample
{
    //Replace MainMethod by Main to run this sample. Redo this step to avoid conflict main method with other samples
    //public static void Main()
    public static void Main()
   {
      StringBuilder sb1 = new StringBuilder("building a string...");
      StringBuilder sb2 = new StringBuilder("building a string...");

      Console.WriteLine("sb1.Equals(sb2): {0}", sb1.Equals(sb2));
      Console.WriteLine("((Object) sb1).Equals((Object) sb2): {0}",
                        ((Object) sb1).Equals((Object) sb2));
      Console.WriteLine("Object.Equals(sb1, sb2): {0}",
                        Object.Equals(sb1, sb2));

      Object sb3 = new StringBuilder("building a string...");
      Console.WriteLine("\nsb3.Equals(sb2): {0}", sb3.Equals(sb2));
   }
}
// The example displays the following output:
//       sb1.Equals(sb2): True
//       ((Object) sb1).Equals(sb2): False
//       Object.Equals(sb1, sb2): False
//
//       sb3.Equals(sb2): False