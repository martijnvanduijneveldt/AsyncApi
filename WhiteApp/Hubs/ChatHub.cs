using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhiteApp.Hubs
{
    /// <summary>
    /// My chat hub
    /// </summary>
    public class ChatHub : Hub<IChatHub>
    {
        /// <summary>
        /// My summary for send
        /// </summary>
        /// <param name="name">Name param</param>
        /// <param name="message">Message param</param>
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.BroadcastMessage( name, message);
        }
        
        /// <summary>
        /// My summary for buzz
        /// </summary>
        /// <param name="name">Name param</param>
        public async Task Buzz(string name)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.BroadcastBuzz(name);
        }
    }

    public interface IChatHub
    {
        /// <summary>
        /// My summary for BroadcastMessage
        /// </summary>
        /// <param name="name">Name param</param>
        /// <param name="message">Message param</param>
        /// <returns></returns>
        public Task BroadcastMessage(string name, string message);
        /// <summary>
        /// My summary for BroadcastBuzz
        /// </summary>
        /// <param name="name">Name param</param>
        /// <returns></returns>
        public Task BroadcastBuzz(string name);
    }
}