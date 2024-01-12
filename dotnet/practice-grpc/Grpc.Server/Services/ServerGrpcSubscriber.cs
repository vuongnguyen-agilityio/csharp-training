using Duplex;
using Grpc.Server.Models;
using System.Collections.Concurrent;

namespace Grpc.Server.Services;
public class ServerGrpcSubscribers
{
  private readonly ILogger _logger;
  private readonly ConcurrentDictionary<string, SubscribersModel> Subscribers = new ConcurrentDictionary<string, SubscribersModel>();

  public ServerGrpcSubscribers(ILoggerFactory loggerFactory)
  {
    _logger = loggerFactory.CreateLogger<ServerGrpcSubscribers>();
  }

  public async Task BroadcastMessageAsync(MessageContent message)
  {
    Console.WriteLine("Server received a message");
    await BroadcastMessages(message);
  }


  public void AddSubscriber(SubscribersModel subscriber)
  {
    bool added = Subscribers.TryAdd(subscriber.Name, subscriber);
    _logger.LogInformation($"New subscriber added: {subscriber.Name}");
    if (!added)
    {
      _logger.LogInformation($"could not add subscriber: {subscriber.Name}");
    }
  }

  public void RemoveSubscriber(SubscribersModel subscriber)
  {
    try
    {
      Subscribers.TryRemove(subscriber.Name, out SubscribersModel item);
      _logger.LogInformation($"Force Remove: {item.Name} - no longer works");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"Could not remove {subscriber.Name}");
    }
  }

  private async Task BroadcastMessages(MessageContent message)
  {
    Console.WriteLine("Server start broadcast message to subscribers");
    foreach (var subscriber in Subscribers.Values)
    {
      Console.WriteLine($"Server start broadcast message to subscriber: {subscriber.Name}");
      var item = await SendMessageToSubscriber(subscriber, message);
      if (item != null)
      {
        RemoveSubscriber(item);
      };
    }
  }

  private async Task<SubscribersModel> SendMessageToSubscriber(SubscribersModel subscriber, MessageContent message)
  {
    try
    {
      _logger.LogInformation($"Broadcasting: {message.Name} - {message.Message}");
      await subscriber.Subscriber.WriteAsync(message);
      return null;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Could not send");
      return subscriber;
    }
  }

}