using System.Collections.Generic;
using AsyncApi.Models.Bindings;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models.Traits
{
    /// <summary>
    /// A reference to a MessageTrait within the AsyncAPI components.
    /// </summary>
    public class MessageTraitReference : Reference
    {
        public MessageTraitReference(string id) : base(id, "#/components/messageTraits/{0}") { }
    }
    
    public class MessageTrait
    {
        /// <summary>
        /// Schema definition of the application headers.
        /// Schema MUST be of type "object". It MUST NOT define the protocol headers.
        /// </summary>
        [YamlMember(Alias = "headers")]
        public JsonSchema Headers { get; set; }

        /// <summary>
        /// Definition of the correlation ID used for message tracing or matching.
        /// </summary>
        [YamlMember(Alias = "correlationId")]
        public ICorrelationId CorrelationId { get; set; }

        /// <summary>
        /// A string containing the name of the schema format/language used to define
        /// the message payload. If omitted, implementations should parse the payload as a Schema object.
        /// </summary>
        [YamlMember(Alias = "schemaFormat")]
        public string SchemaFormat { get; set; }

        /// <summary>
        /// The content type to use when encoding/decoding a message's payload.
        /// The value MUST be a specific media type (e.g. application/json).
        /// When omitted, the value MUST be the one specified on the defaultContentType field.
        /// </summary>
        [YamlMember(Alias = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// A machine-friendly name for the message.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A human-friendly title for the message.
        /// </summary>
        [YamlMember(Alias = "title")]
        public string Title { get; set; }

        /// <summary>
        /// A short summary of what the message is about.
        /// </summary>
        [YamlMember(Alias = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// A verbose explanation of the message.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        /// <summary>
        /// A list of tags for API documentation control.
        /// Tags can be used for logical grouping of messages.
        /// </summary>
        [YamlMember(Alias = "tags")]
        public ISet<Tag> Tags { get; set; } 
            
        /// <summary>
        /// Additional external documentation for this message.
        /// </summary>
        [YamlMember(Alias = "externalDocs")]
        public ExternalDocumentation ExternalDocs { get; set; }

        /// <summary>
        /// A free-form map where the keys describe the name of the protocol
        /// and the values describe protocol-specific definitions for the message.
        /// </summary>
        [YamlMember(Alias = "bindings")]
        public IMessageBindings Bindings { get; set; }

        /// <summary>
        /// An array with examples of valid message objects.
        /// </summary>
        [YamlMember(Alias = "examples")]
        public IList<IDictionary<string, object>> Examples { get; set; }
    }
}