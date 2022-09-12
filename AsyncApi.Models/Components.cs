using System;
using System.Collections.Generic;
using System.Linq;
using AsyncApi.Models.Bindings;
using AsyncApi.Models.Messages;
using AsyncApi.Models.Traits;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models
{
    public class Components
    {
        /// <summary>
        /// An object to hold reusable Schema Objects.
        /// </summary>
        [YamlMember(Alias = "schemas", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, JsonSchema> Schemas { get; set; } = new Dictionary<string, JsonSchema>();

        /// <summary>
        /// An object to hold reusable Message Objects.
        /// </summary>
        [YamlMember(Alias = "messages", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, Message> Messages { get; set; } = new Dictionary<string, Message>();

        /// <summary>
        /// An object to hold reusable Security Scheme Objects.
        /// </summary>
        [YamlMember(Alias = "securitySchemes", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, SecurityScheme> SecuritySchemes { get; set; } = new Dictionary<string, SecurityScheme>();

        /// <summary>
        /// An object to hold reusable Parameter Objects.
        /// </summary>
        [YamlMember(Alias = "parameters", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, Parameter> Parameters { get; set; } = new Dictionary<string, Parameter>();

        /// <summary>
        /// An object to hold reusable Correlation ID Objects.
        /// </summary>
        [YamlMember(Alias = "correlationIds", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, CorrelationId> CorrelationIds { get; set; } = new Dictionary<string, CorrelationId>();
        
        /// <summary>
        /// An object to hold reusable Server Binding Objects.
        /// </summary>
        [YamlMember(Alias = "serverBindings", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, ServerBindings> ServerBindings { get; set; } = new Dictionary<string, ServerBindings>();

        /// <summary>
        /// An object to hold reusable Channel Binding Objects.
        /// </summary>
        [YamlMember(Alias = "channelBindings", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, ChannelBindings> ChannelBindings { get; set; } = new Dictionary<string, ChannelBindings>();

        /// <summary>
        /// An object to hold reusable Operation Binding Objects.
        /// </summary>
        [YamlMember(Alias = "operationBindings", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, OperationBindings> OperationBindings { get; set; } = new Dictionary<string, OperationBindings>();

        /// <summary>
        /// An object to hold reusable Message Binding Objects.
        /// </summary>
        [YamlMember(Alias = "messageBindings", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, MessageBindings> MessageBindings { get; set; } = new Dictionary<string, MessageBindings>();

        
        /// <summary>
        /// An object to hold reusable Operation Trait Objects.
        /// </summary>
        [YamlMember(Alias = "operationTraits", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, OperationTrait> OperationTraits { get; set; } = new Dictionary<string, OperationTrait>();

        /// <summary>
        /// An object to hold reusable Message Trait Objects.
        /// </summary>
        [YamlMember(Alias = "messageTraits", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, MessageTrait> MessageTraits { get; set; } = new Dictionary<string, MessageTrait>();
    }
}