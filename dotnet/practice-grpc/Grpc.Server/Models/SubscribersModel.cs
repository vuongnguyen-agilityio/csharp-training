using Duplex;
using Grpc.Core;

namespace Grpc.Server.Models;
public class SubscribersModel
{
    public IServerStreamWriter<MessageContent> Subscriber { get; set; }

    public string Name { get; set; }
}
