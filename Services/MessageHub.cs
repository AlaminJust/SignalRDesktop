using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRApplication.Services
{
    public class MessageHub : Hub<IHubClient>
    {
        public MessageHub(
            )
        {
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

    }
}
