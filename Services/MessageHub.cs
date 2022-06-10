using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Services
{
    public class MessageHub : Hub<IHubClient>
    {
        public static ConcurrentDictionary<string, MyUserType> MyUsers = new ConcurrentDictionary<string, MyUserType>();
        public MessageHub() { }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId; // Identity of the client. Do something with this connection id
            MyUsers.TryAdd(connectionId, new MyUserType(connectionId)); // Here also you can use current username
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var connectionId = Context.ConnectionId;
            MyUsers.TryRemove(connectionId, out MyUserType user); //  Here you must remove the current username
            await base.OnDisconnectedAsync(exception);
        }
    }

    public class MyUserType
    {
        public string ConnectionId { get; set; }
        public MyUserType(string _connectionId)
        {
            ConnectionId = _connectionId;
        }
    }

}
