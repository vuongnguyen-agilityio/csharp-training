using DotNet.exercises;
using DotNet.samples;

namespace Advanced
{
    /**
     * Define enum Samples into separate topic
     */
    public enum DotNetSamples { Fundamental, XMLSample, DiagnosticsSample, AsynchronousSample, LockStatementSample };
    public enum CollectionSamples { Collection };

    public enum LINQExercises { LINQ };

    internal class Program
    {
        static void Main()
        {
            try
            {
                DotNetSamples s = DotNetSamples.LockStatementSample;
                RunSample(ref s);
            }
            catch (Exception ex)
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
                case DotNetSamples.Fundamental:
                    {
                        Fundamental fundamentalSample = new Fundamental();
                        fundamentalSample.RunTest();
                        break;
                    }
                case CollectionSamples.Collection:
                    {
                        Collection collectionSample = new Collection();
                        collectionSample.RunTest();
                        break;
                    }
                case LINQExercises.LINQ:
                    {
                        LINQ30Exercises lINQ30Exercises = new LINQ30Exercises();
                        lINQ30Exercises.RunTest();
                        break;
                    }
                case DotNetSamples.XMLSample:
                    {
                        XMLSample xmlSample = new XMLSample();
                        xmlSample.RunTest();
                        break;
                    }
                case DotNetSamples.DiagnosticsSample:
                    {
                        DiagnosticsSample diagnosticsSample = new DiagnosticsSample();
                        diagnosticsSample.RunTest();
                        break;
                    }
                case DotNetSamples.AsynchronousSample:
                    {
                        Asynchronous asynchronousSample = new Asynchronous();
                        asynchronousSample.RunTest().GetAwaiter().GetResult();
                        break;
                    }
                case DotNetSamples.LockStatementSample:
                    {
                        LockStatementSample lockStatementSample = new LockStatementSample();
                        lockStatementSample.RunTest().GetAwaiter().GetResult();
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