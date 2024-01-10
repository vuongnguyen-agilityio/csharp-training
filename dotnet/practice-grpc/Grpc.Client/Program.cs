using Grpc.Client;
using Grpc.Client.Services;
using Grpc.Client.Channel;

// The port number must match the port of the gRPC server.
using var channel = ChannelService.CreateAuthenticationChannel("https://localhost:7164");
var client = new Greeter.GreeterClient(channel);

static void DisplayOptions() {
  Console.WriteLine("--------");
  Console.WriteLine("Select Options:");
  Console.WriteLine("<1>: Run Greeting");
  Console.WriteLine("<Esc>: Quit");
  Console.WriteLine("--------");
}

DisplayOptions();

ConsoleKeyInfo consoleKeyInfo;
do
{
  consoleKeyInfo = Console.ReadKey(intercept: true);
  switch (consoleKeyInfo.KeyChar)
  {
    case '1':
      Console.WriteLine("Selected <1>: Running GreeterFunc.SayHello.");
      await GreeterFunc.SayHello(client);
      Console.WriteLine("Finished GreeterFunc.SayHello.");
      DisplayOptions();
      break;
  }
} while (consoleKeyInfo.Key != ConsoleKey.Escape);