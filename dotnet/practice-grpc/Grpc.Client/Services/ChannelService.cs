using Grpc.Net.Client;
using Grpc.Core;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;

namespace Grpc.Client.Channel;

public class ChannelService() {

  public static async Task<GrpcChannel> CreateAuthenticationChannel(string address) {
    string token = await Authenticate(address);
    var credentials = CallCredentials.FromInterceptor((context, metadata) =>
      {
        Console.WriteLine("Adding Access Token to Channel");
        Console.WriteLine($"Token: {token}");
        if (!string.IsNullOrEmpty(token))
        {
          metadata.Add("Authorization", $"Bearer {token}");
        }
        Console.WriteLine("Added Access Token to Channel");
        return Task.CompletedTask;
      });

    Console.WriteLine("Credentials: ", credentials);

    // SslCredentials is used here because this channel is using TLS.
    // Channels that aren't using TLS should use ChannelCredentials.Insecure instead.
    var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
      {
        Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
      });

    return channel;
  }

  private static async Task<string> Authenticate(string address)
  {
    Console.WriteLine($"Authenticating as {Environment.UserName}...");
    var httpClient = new HttpClient();
    var request = new HttpRequestMessage
    {
      RequestUri = new Uri($"{address}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
      Method = HttpMethod.Get,
      Version = new Version(2, 0)
    };
    var tokenResponse = await httpClient.SendAsync(request);
    tokenResponse.EnsureSuccessStatusCode();

    var token = await tokenResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Successfully authenticated.");

    return token;
  }
}