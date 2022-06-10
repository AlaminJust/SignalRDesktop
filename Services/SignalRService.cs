using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDesktop.Services
{
    public class SignalRService
    {
        private readonly IHubContext<MessageHub, IHubClient> _hubContext;

        public SignalRService(IHubContext<MessageHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAllAsync(Message message)
        {
            await _hubContext.Clients.All.BroadcastMessageAsync(message);
        }

        public async Task SendToUserAsync(string connectionId, Message message)
        {
            await _hubContext.Clients.Clients(MessageHub.MyUsers.Keys.ToList().Where(x => x == connectionId)).BroadcastMessageAsync(message);
        }
    }
}
