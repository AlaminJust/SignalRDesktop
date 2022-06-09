using System.Threading.Tasks;

namespace SignalRApplication.Services
{
    public interface IHubClient
    {
        Task BroadcastMessage(string message);
    }
}
