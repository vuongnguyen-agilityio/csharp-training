using Duplex;
using Grpc.Server.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ServerGrpcSubscribers _serverGrpcSubscribers;
    public IndexModel(ServerGrpcSubscribers serverGrpcSubscribers, ILogger<IndexModel> logger)
    {
        _logger = logger;
        _serverGrpcSubscribers = serverGrpcSubscribers;
    }

    public void OnGet()
    {

    }

    public async Task OnPostAsync(string message)
    {
        await _serverGrpcSubscribers.BroadcastMessageAsync(
          new MessageContent { Message = message, Name = "Server" });
    }
}
