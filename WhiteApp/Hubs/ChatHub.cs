using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhiteApp.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.BroadcastMessage( name, message);
        }
        
        public async Task Buzz(string name)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.BroadcastBuzz(name);
        }
    }

    public interface IChatHub
    {
        public Task BroadcastMessage(string name, string message);
        public Task BroadcastBuzz(string name);
    }
}