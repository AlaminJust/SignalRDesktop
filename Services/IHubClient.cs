using SignalRDesktop.Services;
using System.Threading.Tasks;

namespace SignalRApplication.Services
{
    public interface IHubClient
    {
        Task BroadcastMessageAsync(Message message);
    }
}
