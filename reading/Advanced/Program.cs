using System;
using System.Collections.Generic;
using Advanced.samples.BookTestClient;
using static Advanced.samples.EventSamples;
using static Advanced.samples.DelegateSample;
using static Advanced.samples.DeletageGenericType;
using static Advanced.samples.ExtensionsMethodSample;
using static Advanced.samples.EventBaseClassSample;
using static Advanced.samples.AttributeClasses;
using Advanced.samples;

namespace Advanced
{
    /**
     * Define enum Samples into separate topic
     */
    public enum DelegateSamples { Delegate, DelegateGenericType, DelegateBookStore };
    public enum EventSamples { Event, EventBaseClass };
    public enum MethodSamples { ExtensionMethod };
    public enum ClassSamples { AttributeClasses };

    internal class Program
    {
        static void Main()
        {
            try
            {
                ClassSamples s = ClassSamples.AttributeClasses;
                RunSample(ref s);
            } catch (Exception ex)
            {
                Console.WriteLine("Sample threw Error: " + ex.Message);
            }
        }

        /**
         * Implement a generic method to run sample for each topics
         */
        static void RunSample<T>(ref T sample)
        {
            switch (sample)
            {
                case DelegateSamples.Delegate:
                    {
                        // What Sample Do?
                        // 1. Create sample delegate
                        // 2. Assign methods to delegate
                        // 3. UnAssign methods from delegate
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
                        break;
                    }
                case DelegateSamples.DelegateGenericType:
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
                        break;
                    }
                case DelegateSamples.DelegateBookStore:
                    {
                        // What Sample Do?
                        // 1. Do a bookstore sample to understand more about how delegate apply
                        TestBookDB.RunTest();
                        break;
                    }
                case EventSamples.Event:
                    {
                        // What Sample Do?
                        // 1. Create a Pub/Sub event
                        var pub = new Publisher();
                        var sub1 = new Subscriber("sub1", pub);
                        var sub2 = new Subscriber("sub2", pub);

                        // Call the method that raises the event.
                        pub.DoSomething();

                        // Keep the console window open
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    }
                case EventSamples.EventBaseClass:
                    {
                        // What Sample Do?
                        // 1. Create a standard way to declare events in a base class
                        //Create the event publishers and subscriber
                        var circle = new Circle(54);
                        var rectangle = new Rectangle(12, 9);
                        var container = new ShapeContainer();

                        // Add the shapes to the container.
                        container.AddShape(circle);
                        container.AddShape(rectangle);

                        // Cause some events to be raised.
                        circle.Update(57);
                        rectangle.Update(7, 7);

                        // Keep the console window open in debug mode.
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case MethodSamples.ExtensionMethod:
                    {
                        // What Sample Do?
                        // 1. Create a extension method to count word in a string
                        string str = "Hello Extension Methods";
                        int i = str.WordCount();
                        break;
                    }
                case ClassSamples.AttributeClasses:
                    {
                        AttributeClasses attributeClasses = new AttributeClasses();
                        attributeClasses.RunTest();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter Topic to Run Samples");
                        break;
                    }
            }
        }
    }
}