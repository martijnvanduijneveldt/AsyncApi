using System.Collections.Generic;
using AsyncApi.Models.Bindings;
using AsyncApi.Models.Traits;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models.Messages
{
    public class Message
    {
        /// <summary>
        /// Unique string used to identify the message. The id MUST be unique among all messages
        /// described in the API. The messageId value is case-sensitive. Tools and libraries MAY
        /// use the messageId to uniquely identify a message, therefore, it is RECOMMENDED to
        /// follow common programming naming conventions.
        /// </summary>
        [YamlMember(Alias = "messageId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string MessageId { get; set; }

        /// <summary>
        /// Schema definition of the application headers. Schema MUST be of type “object”.
        /// It MUST NOT define the protocol headers.
        /// </summary>
        [YamlMember(Alias = "headers", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema Headers { get; set; }

        /// <summary>
        /// Definition of the message payload. It can be of any type but defaults to Schema object.
        /// </summary>
        [YamlMember(Alias = "payload", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema Payload { get; set; }

        /// <summary>
        /// Definition of the correlation ID used for message tracing or matching.
        /// </summary>
        [YamlMember(Alias = "correlationId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public ICorrelationId CorrelationId { get; set; }

        /// <summary>
        /// A string containing the name of the schema format used to define the message payload.
        /// If omitted, implementations should parse the payload as a Schema object.
        /// </summary>
        [YamlMember(Alias = "schemaFormat", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string SchemaFormat { get; set; }

        /// <summary>
        /// The content type to use when encoding/decoding a message’s payload.
        /// The value MUST be a specific media type (e.g. application/json).
        /// </summary>
        [YamlMember(Alias = "contentType", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string ContentType { get; set; }

        /// <summary>
        /// A machine-friendly name for the message.
        /// </summary>
        [YamlMember(Alias = "name", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Name { get; set; }

        /// <summary>
        /// A human-friendly title for the message.
        /// </summary>
        [YamlMember(Alias = "title", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Title { get; set; }

        /// <summary>
        /// A short summary of what the message is about.
        /// </summary>
        [YamlMember(Alias = "summary", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Summary { get; set; }

        /// <summary>
        /// A verbose explanation of the message. CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// A list of tags for API documentation control. Tags can be used for logical grouping of messages.
        /// </summary>
        [YamlMember(Alias = "tags", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ISet<Tag> Tags { get; set; } = new HashSet<Tag>();

        public bool ShouldSerializeTags()
        {
            return Tags != null && Tags.Count > 0;
        }

        /// <summary>
        /// Additional external documentation for this message.
        /// </summary>
        [YamlMember(Alias = "externalDocs", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public ExternalDocumentation ExternalDocs { get; set; }

        /// <summary>
        /// A free-form map where the keys describe the name of the protocol and the values describe protocol-specific definitions for the message.
        /// </summary>
        [YamlMember(Alias = "bindings", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IMessageBindings Bindings { get; set; }

        /// <summary>
        /// An array with examples of valid message objects.
        /// </summary>
        [YamlMember(Alias = "examples", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IList<MessageExample> Examples { get; set; } = new List<MessageExample>();
        
        public bool ShouldSerializeExamples()
        {
            return Examples != null && Examples.Count > 0;
        }

        /// <summary>
        /// A list of traits to apply to the message object.
        /// Traits MUST be merged into the message object using the JSON Merge Patch algorithm in the same order they are defined here.
        /// The resulting object MUST be a valid Message Object.
        /// </summary>
        [YamlMember(Alias = "traits", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IList<MessageTraitReference> Traits { get; set; } = new List<MessageTraitReference>();

        public bool ShouldSerializeTraits()
        {
            return Traits != null && Traits.Count > 0;
        }
    }
}