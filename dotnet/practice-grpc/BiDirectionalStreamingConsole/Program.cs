using BiDirectionalStreamingConsole.Services;
using Duplex;

namespace BiDirectionalStreamingConsole
{
  class Program
  {
    static async Task<int> Main(string[] args)
    {
      var name = "BiDirectionalStreaming";
      if (args.Length != 1)
      {
        Console.WriteLine("No name provided. Using <BiDirectionalStreaming>");
        name = args[0];
      }

      // The port number must match the port of the gRPC server.
      using var channel = ChannelService.CreateAuthenticationChannel("https://localhost:7164");
      var client = new Messenger.MessengerClient(channel);

      using (var duplex = client.SendData())
      {
        Console.WriteLine($"Connected as {name}. Send empty message to quit.");

        // Dispatch, this could be racy
        var responseTask = Task.Run(async () =>
        {
          while (await duplex.ResponseStream.MoveNext(CancellationToken.None))
          {
            Console.WriteLine($"{duplex.ResponseStream.Current.Name}: {duplex.ResponseStream.Current.Message}");
          }
        });

        var line = Console.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
          await duplex.RequestStream.WriteAsync(new MessageContent { Name = name, Message = line });
          line = Console.ReadLine();
        }
        await duplex.RequestStream.CompleteAsync();
      }

      Console.WriteLine("Shutting down");
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();

      return 0;
    }
  }
}