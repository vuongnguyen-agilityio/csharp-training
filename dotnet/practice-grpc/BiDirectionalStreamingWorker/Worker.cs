using BiDirectionalStreamingWorker.Services;
using Duplex;

namespace BiDirectionalStreamingWorker;
public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;

  public Worker(ILogger<Worker> logger)
  {
    _logger = logger;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    // The port number must match the port of the gRPC server.
    using var channel = ChannelService.CreateAuthenticationChannel("https://localhost:7164");

    var name = "worker_client";
    while (!stoppingToken.IsCancellationRequested)
    {
      _logger.LogInformation($"Worker running at: {DateTime.Now}");
      var client = new Messenger.MessengerClient(channel);

      using (var sendData = client.SendData())
      {
        Console.WriteLine($"Connected as {name}. Send empty message to quit.");

        var responseTask = Task.Run(async () =>
        {
          while (await sendData.ResponseStream.MoveNext(stoppingToken))
          {
            Console.WriteLine($"{sendData.ResponseStream.Current.Name}: {sendData.ResponseStream.Current.Message}");
          }
        });

        var line = Console.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
          await sendData.RequestStream.WriteAsync(new MessageContent { Name = name, Message = line });
          line = Console.ReadLine();
        }
        await sendData.RequestStream.CompleteAsync();
      }

      await Task.Delay(1000, stoppingToken);
    }
  }
}