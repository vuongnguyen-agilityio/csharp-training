public class DeconstructExample
{
    //Replace MainMethod by Main to run this sample. Redo this step to avoid conflict main method with other samples
    //public static void Main()
    void MainMethod()
    {
        var rect = new Rectangle (3, 4);
        var (width, height) = rect;
        Console.WriteLine (width + " " + height);
    }

    class Rectangle
    {
        public readonly float Width, Height;

        public Rectangle (float width, float height)
        {
        Width = width;
        Height = height;
        }

        //This help to deconstruct
        public void Deconstruct (out float width, out float height)
        {
        width = Width;
        height = Height;
        }
    }
}
