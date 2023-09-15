using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.samples
{
    internal class Collection
    {
        /*
         * Sample with index in collection
         */
        protected void IndexableCollectionSample()
        {
            // Create a list of strings by using a
            // collection initializer.
            var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

            // Iterate through the list.
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            // Output: chinook coho pink sockeye

            // Remove an element from the list by specifying
            // the object.
            salmons.Remove("coho");


            // Iterate using the index:
            for (var index = 0; index < salmons.Count; index++)
            {
                Console.Write(salmons[index] + " ");
            }
            // Output: chinook pink sockeye

            // Add the removed element
            salmons.Add("coho");
            // Iterate through the list.
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            // Output: chinook pink sockeye coho
        }

        /*
         * Sample with key-pair value in collection
         */
        protected void KeyValuePairSample()
        {
            Dictionary<string, Element> elements = BuildDictionary();

            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;

                Console.WriteLine("key: " + kvp.Key);
                Console.WriteLine("values: " + theElement.Symbol + " " +
                    theElement.Name + " " + theElement.AtomicNumber);
            }
        }

        public class Element
        {
            public required string Symbol { get; init; }
            public required string Name { get; init; }
            public required int AtomicNumber { get; init; }
        }

        private static Dictionary<string, Element> BuildDictionary() =>
        new()
        {
            {"K",
                new (){ Symbol="K", Name="Potassium", AtomicNumber=19}},
            {"Ca",
                new (){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
            {"Sc",
                new (){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
            {"Ti",
                new (){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };

        /*
         * Sample with iterators (foreach)
         */
        protected void IteratorSample()
        {
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine();
            // Output: 6 8 10 12 14 16 18
        }
        private static IEnumerable<int> EvenSequence(
            int firstNumber, int lastNumber)
        {
            // Yield even numbers in the range.
            for (var number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public void RunTest()
        {
            IndexableCollectionSample();
            KeyValuePairSample();
            IteratorSample();
        }
    }
}
