// Declare a delegate
delegate T Callback<T>();

class SampleClass
{
    public void InstanceMethodVoid()
    {
      Console.WriteLine("A message from the instance method.");
    }

  public bool InstanceMethodBool ()
    {
      Console.WriteLine("A message from the instance method.");
      return true;
    }

    // return object:null instead void can avoid the generic type not allow void
    static public object StaticMethod()
    {
      Console.WriteLine("A message from the static method.");
      return null;
    }
}

class TestSampleClass
{
    static void Main()
    {
        var sc = new SampleClass();

        // Map the delegate to the instance method:
        Callback<void> d = sc.InstanceMethodVoid; // <== this callback will not work because void is not a type.
        Callback<bool> a = sc.InstanceMethodBool;
        d();

        // Map to the static method:
        d = SampleClass.StaticMethod;
        d();
    }
}