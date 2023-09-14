using Advanced.samples.BookTestClient;
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
                DelegateSamples s = DelegateSamples.Delegate;
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
                        DelegateSample delegateSample = new DelegateSample();
                        delegateSample.RunTest();
                        break;
                    }
                case DelegateSamples.DelegateGenericType:
                    {
                        DeletageGenericType delegateGenericType = new DeletageGenericType();
                        delegateGenericType.RunTest();
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
                        EventSample eventSample = new EventSample();
                        eventSample.RunTest();
                        break;
                    }
                case EventSamples.EventBaseClass:
                    {
                        EventBaseClassSample eventBaseClassSample = new EventBaseClassSample();
                        eventBaseClassSample.RunTest();
                        break;
                    }
                case MethodSamples.ExtensionMethod:
                    {
                        ExtensionMethodSample methodSample = new ExtensionMethodSample();
                        methodSample.RunTest();
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