using System;
using System.Collections.Generic;
using System.Reflection;
using AsyncApi.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;

namespace AsyncApi.SignalR
{
    public static class AsyncApiSignalRApplicationBuilderExtensions
    {
        public static void UseAsyncApiSignalRHub<THub, THubInterface>(this IApplicationBuilder applicationBuilder, string hubRoute)
            where THub : Hub<THubInterface>
            where THubInterface : class
        {
            var serviceInstance = applicationBuilder.ApplicationServices.GetService(typeof(AsyncApiBuilder)) as AsyncApiBuilder;

            if (serviceInstance == null)
            {
                throw new NotSupportedException("You need to instantiate the AsyncApiBuilder");
            }
            
            var serverMethods = GetHubMethods(typeof(THub));
            foreach (var methodInfo in serverMethods)
            {
                serviceInstance.AddServerMethod(hubRoute, methodInfo);
            }

            // var clientMethods = asyncApiSignalROption.Value.HubInterfaceType.GetMethods(BindingFlags.Instance|BindingFlags.Public);
            // foreach (var methodInfo in clientMethods)
            // {
            //     serviceInstance.AddClientMethod(hubRoute, methodInfo);
            // }
        }
        
        private static List<MethodInfo> GetHubMethods(Type type)
        {
            var methods = new List<MethodInfo>();
            var cursor = type;
            while (cursor != null)
            {
                methods.AddRange(cursor.GetMethods(BindingFlags.Instance | BindingFlags.Public |
                                                   BindingFlags.DeclaredOnly));
                cursor = cursor.BaseType;
                if (cursor != null && cursor.IsGenericType && cursor.GetGenericTypeDefinition() == typeof(Hub<>))
                {
                    break;
                }
            }

            return methods;
        }
    }
}