using System.Collections.Generic;
using System.Reflection;
using System.Xml.XPath;
using AsyncApi.Core.Helper;
using LEGO.AsyncAPI;
using LEGO.AsyncAPI.Models;

namespace AsyncApi.Core
{
    public class AsyncApiBuilder
    {
        private readonly XPathNavigator _xmlComments;
        private AsyncApiDocument _document;

        public AsyncApiBuilder(XPathNavigator xmlComments)
        {
            _xmlComments = xmlComments;
            _document = new AsyncApiDocument
            {
                DefaultContentType = "application/json"
            };
        }

        public AsyncApiBuilder AddInfo(string title, string version)
        {
            _document.Info = new AsyncApiInfo
            {
                Title = title,
                Version = version
            };
            
            return this;
        }

        public AsyncApiBuilder AddServerMethod(string route, MethodInfo method)
        {
            if (!_document.Channels.ContainsKey(route))
            {
                _document.Channels.Add(route, new AsyncApiChannel());
            }

            var channel = _document.Channels[route];
            channel.Publish ??= new AsyncApiOperation();

            _document.Components ??= new AsyncApiComponents();
            if (!_document.Components.Messages.ContainsKey(method.Name))
            {
                _document.Components.Messages.Add(method.Name, GetMessageForMethod(method));
            }

            var messageRef = new AsyncApiMessage
            {
                Reference = new AsyncApiReference
                {
                    Type = ReferenceType.Message,
                    Id = method.Name
                }
            };
            channel.Publish.Message.Add(messageRef);

            return this;
        }

        private AsyncApiMessage GetMessageForMethod(MethodInfo method)
        {
            var message = new AsyncApiMessage
            {
                Title = method.Name,
                Name = method.Name,
                Payload = new AsyncApiSchema
                {
                    Type = SchemaType.Object
                },
                
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

                var parameterDescription = GetMethodXmlInfos(methodNode);

                var parameters = method.GetParameters();
                foreach (var parameter in parameters)
                {
                    var property = new AsyncApiSchema
                    {
                        Type = GetSchemaType(parameter),
                        Description = parameterDescription.GetValueOrDefault(parameter.Name, "")
                    };
                    message.Payload.Properties.Add(parameter.Name, property);
                }

            }


            return message;
        }

        private static SchemaType GetSchemaType(ParameterInfo parameterInfo)
        {
            if (parameterInfo.ParameterType ==typeof( string))
            {
                return SchemaType.String;
            }

            if (parameterInfo.ParameterType == typeof(int)
                || parameterInfo.ParameterType == typeof(sbyte)
                || parameterInfo.ParameterType == typeof(byte)
                || parameterInfo.ParameterType == typeof(short)
                || parameterInfo.ParameterType == typeof(ushort)
                || parameterInfo.ParameterType == typeof(int)
                || parameterInfo.ParameterType == typeof(uint)
                || parameterInfo.ParameterType == typeof(long)
                || parameterInfo.ParameterType == typeof(ulong)
                )
            {
                return SchemaType.Number;
            }
            
            
            if (parameterInfo.ParameterType.IsArray)
            {
                return SchemaType.Array;
            }

            if (parameterInfo.ParameterType == typeof(bool))
            {
                return SchemaType.Boolean;
            }

            return SchemaType.Object;
        }
        
        private Dictionary<string, string> GetMethodXmlInfos(XPathNavigator methodNode)
        {
            var mapping = new Dictionary<string, string>();
            var parameters = methodNode.Select("param");
            foreach (XPathNavigator parameter in parameters)
            {
                var nameAttribute = parameter.GetAttribute("name", "");
                mapping.Add(nameAttribute, parameter.Value);
            }

            return mapping;
        }
        
        public string Serialize()
        {
            return _document.SerializeAsYaml(AsyncApiVersion.AsyncApi2_0);
        }
    }
}