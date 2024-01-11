using Duplex;
using Grpc.Core;
using Grpc.Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace Grpc.Server.Services;

[Authorize]
public class DuplexService : Messenger.MessengerBase, IDisposable
{
  private readonly ILogger _logger;
  private readonly ServerGrpcSubscribers _serverGrpcSubscribers;

  public DuplexService(ILoggerFactory loggerFactory, ServerGrpcSubscribers serverGrpcSubscribers)
  {
    _logger = loggerFactory.CreateLogger<DuplexService>();
    _serverGrpcSubscribers = serverGrpcSubscribers;
  }

  public override async Task SendData(IAsyncStreamReader<MessageContent> requestStream, IServerStreamWriter<MessageContent> responseStream, ServerCallContext context)
  {
    var httpContext = context.GetHttpContext();
    _logger.LogInformation($"Connection id: {httpContext.Connection.Id}");

    if (!await requestStream.MoveNext())
    {
      return;
    }

    var user = requestStream.Current.Name;
    _logger.LogInformation($"{user} connected");
    var subscriber = new SubscribersModel
    {
      Subscriber = responseStream,
      Name = user
    };

    _serverGrpcSubscribers.AddSubscriber(subscriber);

    do
    {
      await _serverGrpcSubscribers.BroadcastMessageAsync(requestStream.Current);
    } while (await requestStream.MoveNext());

    _serverGrpcSubscribers.RemoveSubscriber(subscriber);
    _logger.LogInformation($"{user} disconnected");
  }

  public void Dispose()
  {
    _logger.LogInformation("Cleaning up");
  }
}