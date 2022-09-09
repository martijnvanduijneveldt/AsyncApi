using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhiteApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }
        
        public async Task Buzz(string name)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastBuzz", name);
        }
    }
}