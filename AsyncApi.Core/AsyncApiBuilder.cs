using System.Reflection;
using AsyncApi.Models;
using AsyncApi.Models.Messages;
using YamlDotNet.Serialization;

namespace AsyncApi.SignalR
{
    public class AsyncApiBuilder
    {
        private AsyncApiDocument _document;
        private readonly ISerializer serializer;

        public AsyncApiBuilder()
        {
            _document = new AsyncApiDocument();
            serializer = new SerializerBuilder()
                .Build();
        }

        public AsyncApiBuilder AddInfo(string title, string version)
        {
            _document.Info = new Info(title, version);
            return this;
        }

        public AsyncApiBuilder AddServerMethod(string route, MethodInfo method)
        {
            if (!_document.Channels.ContainsKey(route))
            {
                _document.Channels.Add(route, new ChannelItem());    
            }
            var channel = _document.Channels[route];
            channel.Publish ??= new Operation();
            
            _document.Components ??= new Components();
            if (!_document.Components.Messages.ContainsKey(method.Name))
            {
                _document.Components.Messages.Add(method.Name, GetMessageForMethod(method));
            }

            var messageRef = new MessageReference(method.Name);
            channel.Publish.Message.OneOf.Add(messageRef);

            return this;
        }

        private Message GetMessageForMethod(MethodInfo method)
        {
            var message = new Message
            {
                Name = method.Name,
            };

            return message;
        }
        
        public string Serialize()
        {
            return serializer.Serialize(_document);
        }
    }
}