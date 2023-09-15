using DotNet.samples;

namespace Advanced
{
    /**
     * Define enum Samples into separate topic
     */
    public enum DotNetSamples { Fundamental };
    public enum CollectionSamples { Collection };

    internal class Program
    {
        static void Main()
        {
            try
            {
                CollectionSamples s = CollectionSamples.Collection;
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
                default:
                    {
                        Console.WriteLine("Enter Topic to Run Samples");
                        break;
                    }
            }
        }
    }
}