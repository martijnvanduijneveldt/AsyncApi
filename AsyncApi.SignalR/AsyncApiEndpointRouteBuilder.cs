using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;

namespace AsyncApi.UI
{
    public static class AsyncApiSignalRApplicationBuilderExtensions
    {
        public static void UseAsyncApiSignalRHub<THub, THubInterface>(this IApplicationBuilder applicationBuilder, string hubRoute)
            where THub : Hub<THubInterface>
            where THubInterface : class
        {
            
        }
    }
}