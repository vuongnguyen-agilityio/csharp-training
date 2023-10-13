using System.Diagnostics;
using System.Text;

namespace DotNet.samples
{
    internal class Asynchronous
    {
        HttpClient s_client = new()
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        IEnumerable<string> s_urlList = new string[]
        {
            "https://learn.microsoft.com",
            "https://learn.microsoft.com/aspnet/core",
            "https://learn.microsoft.com/azure",
            "https://learn.microsoft.com/azure/devops",
            "https://learn.microsoft.com/dotnet",
            "https://learn.microsoft.com/dynamics365",
            "https://learn.microsoft.com/education",
            "https://learn.microsoft.com/enterprise-mobility-security",
            "https://learn.microsoft.com/gaming",
            "https://learn.microsoft.com/graph",
            "https://learn.microsoft.com/microsoft-365",
            "https://learn.microsoft.com/office",
            "https://learn.microsoft.com/powershell",
            "https://learn.microsoft.com/sql",
            "https://learn.microsoft.com/surface",
            "https://learn.microsoft.com/system-center",
            "https://learn.microsoft.com/visualstudio",
            "https://learn.microsoft.com/windows",
            "https://learn.microsoft.com/xamarin"
        };

        /*
         * Process asynchronous tasks as they complete
         */
        async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Task<int>> downloadTasksQuery =
                from url in s_urlList
                select ProcessUrlAsync(url, s_client);

            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            int total = 0;
            while (downloadTasks.Any())
            {
                Task<int> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                total += await finishedTask;
            }

            stopwatch.Stop();

            Console.WriteLine($"\nTotal bytes returned:    {total:#,#}");
            Console.WriteLine($"Elapsed time:              {stopwatch.Elapsed}\n");
        }

        static async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

            return content.Length;
        }

        /*
         * Asynchronous file access
         */
        public async Task ProcessMultipleWritesAsync()
        {
            IList<FileStream> sourceStreams = new List<FileStream>();

            try
            {
                Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
                string path = $"{Directory.GetCurrentDirectory().Replace("bin\\Debug\\net7.0", "samples\\tempfolder")}";
                Directory.CreateDirectory(path);
                Console.WriteLine("Created Folder: " + path);

                IList<Task> writeTaskList = new List<Task>();

                for (int index = 1; index <= 10; ++index)
                {
                    string fileName = $"file-{index:00}.txt";
                    string filePath = $"{path}/{fileName}";

                    string text = $"In file {index}{Environment.NewLine}";
                    byte[] encodedText = Encoding.Unicode.GetBytes(text);

                    var sourceStream =
                        new FileStream(
                            filePath,
                            FileMode.Create, FileAccess.Write, FileShare.None,
                            bufferSize: 4096, useAsync: true);

                    Task writeTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                    sourceStreams.Add(sourceStream);

                    writeTaskList.Add(writeTask);
                }

                await Task.WhenAll(writeTaskList);
            }
            finally
            {
                foreach (FileStream sourceStream in sourceStreams)
                {
                    sourceStream.Close();
                }
            }
        }

        public async Task RunTest() {
            Console.WriteLine("Running Asynchronous Test:");
            await SumPageSizesAsync();

            Console.WriteLine("Running Asynchronous File Access:");
            await ProcessMultipleWritesAsync();
        }

    }
}
