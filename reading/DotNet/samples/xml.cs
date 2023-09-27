using System.Xml.Linq;
using System.Xml;

namespace DotNet.samples
{
    internal class XMLSample
    {
        /*
         * 1. Write a program in C# Sharp to shows how the three parts of a query operation execute
         * Input:
         * int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
         * 
         * Expected Output:
         * 1: The numbers which produce the remainder 0 after divided by 2 are :
         * 0 2 4 6 8
         * 
         * 2: Generate and Save XML to xml-sample.xml file
         * 
         * 3: Read the saved xml-sample.xml and print to console
         * 
         * 4: Load the saved xml-sample.xml and print to console
         */
        int[] ListDividedByTwos(int[] numbers, int dividedBy = 2)
        {
            int[] res = numbers.Where(num => num % dividedBy == 0).ToArray();
            string xmlSamplePath = $"{Directory.GetCurrentDirectory().Replace("bin\\Debug\\net7.0", "samples\\xml-sample.xml")}";

            // Print results
            // 2: Generate and Save XML to xml-sample.xml file
            XDocument doc = new XDocument();
            doc.Add(new XElement("root", res.Select(x => new XElement("item", x))));
            Console.WriteLine("Generated XML sample: ");
            Console.WriteLine(doc);

            // 3: Read the saved xml-sample.xml and print to console
            doc.Save(xmlSamplePath);

            Console.WriteLine("Read and Generated XML sample from saved file: ");
            XmlTextReader reader = new XmlTextReader(xmlSamplePath);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name + ">");
                        break;

                    case XmlNodeType.Text: //Display the text in each element.
                        Console.Write(reader.Value);
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.WriteLine("</" + reader.Name + ">");
                        break;
                }
            }

            // 4: Load the saved xml-sample.xml and print to console
            Console.WriteLine("Load and Generated XML sample from saved file: ");
            XElement booksFromFile = XElement.Load(xmlSamplePath);
            Console.WriteLine(booksFromFile);

            return res;
        }

        public void RunTest()
        {
            Console.WriteLine("1. Start ListDividedByTwos: ");
            ListDividedByTwos(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine();
        }
    }
}
