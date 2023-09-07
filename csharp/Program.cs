using System.Drawing;
using static type.samples.ClassObject;
using static type.samples.Deconstruct;

internal class Program
{
    private static void Main(string[] args)
    {
        /* Run Class-Object Sample */
        var packard = new Automobile("Packard", "Custom Eight", 1948);
        Console.WriteLine(packard);

        /* Run Deconstruct Sample */
        var rect = new RectangleSample(3, 4);
        var (width, height) = rect;
        Console.WriteLine(width + " " + height);
    }
}