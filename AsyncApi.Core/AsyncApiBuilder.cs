using System.Reflection;
using System.Xml.XPath;
using AsyncApi.Core.Helper;
using AsyncApi.Models;
using AsyncApi.Models.Messages;
using YamlDotNet.Serialization;

namespace AsyncApi.Core
{
    public class AsyncApiBuilder
    {
        private readonly XPathNavigator _xmlComments;
        private AsyncApiDocument _document;
        private readonly ISerializer serializer;

        public AsyncApiBuilder(XPathNavigator xmlComments)
        {
            _xmlComments = xmlComments;
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

            const string MemberXPath = "/doc/members/member[@name='{0}']";

            var name = XmlCommentsNodeNameHelper.GetMemberNameForMethod(method);

            var methodNode = _xmlComments.SelectSingleNode(string.Format(MemberXPath, name));


            if (methodNode != null)
            {
                var summaryNode = methodNode.SelectSingleNode("summary");
                if (summaryNode != null){
                    message.Summary = XmlCommentsTextHelper.Humanize(summaryNode.InnerXml);
                }
                var remarksNode = methodNode.SelectSingleNode("remarks");
                if (remarksNode != null)
                {
                    message.Description = XmlCommentsTextHelper.Humanize(remarksNode.InnerXml);
                }
                    
            }


            return message;
        }

        public string Serialize()
        {
            return serializer.Serialize(_document);
        }
    }
}