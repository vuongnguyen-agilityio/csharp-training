public class PrintMetricExample
{
    //Replace MainMethod by Main to run this sample. Redo this step to avoid conflict main method with other samples
    //public static void Main()
    void MainMethod()
    {
      int[,] matrix = new int[3,3];
      for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
          matrix[i,j] = i * 4 + j;
          Console.WriteLine(matrix);
    }
}