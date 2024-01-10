
namespace Grpc.Client.Services;

public class GreeterFunc {
  public static async Task SayHello(Greeter.GreeterClient client) {
    Console.WriteLine("Sending GreeterClient");
    var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
    Console.WriteLine("Greeting: " + reply.Message);
  }
}