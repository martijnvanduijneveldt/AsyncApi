using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    public class AsyncApiDocument
    {
        /// <summary>
        /// Specifies the AsyncAPI Specification version being used.
        /// </summary>
        [YamlMember(Alias = "asyncapi", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string AsyncApi { get; } = "2.4.0";
        
        /// <summary>
        /// Identifier of the application the AsyncAPI document is defining.
        /// </summary>
        [YamlMember(Alias = "id", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Id { get; set; }

        /// <summary>
        /// Provides metadata about the API. The metadata can be used by the clients if needed.
        /// </summary>
        [YamlMember(Alias = "info", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public Info Info { get; set; }

        /// <summary>
        /// Provides connection details of servers.
        /// </summary>
        [YamlMember(Alias = "servers", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public Dictionary<string, Server> Servers { get; set; } = new Dictionary<string, Server>();

        /// <summary>
        /// A string representing the default content type to use when encoding/decoding a message's payload.
        /// The value MUST be a specific media type (e.g. application/json).
        /// </summary>
        [YamlMember(Alias = "defaultContentType", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string DefaultContentType { get; set; } = "application/json";

        /// <summary>
        /// The available channels and messages for the API.
        /// </summary>
        [YamlMember(Alias = "channels", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, ChannelItem> Channels { get; set; } = new Dictionary<string, ChannelItem>();

        /// <summary>
        /// An element to hold various schemas for the specification.
        /// </summary>
        [YamlMember(Alias = "components", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public Components Components { get; set; }

        /// <summary>
        /// A list of tags used by the specification with additional metadata.
        /// Each tag name in the list MUST be unique.
        /// </summary>
        [YamlMember(Alias = "tags", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public ISet<Tag> Tags { get; } = new HashSet<Tag>();

        /// <summary>
        /// Additional external documentation.
        /// </summary>
        [YamlMember(Alias = "externalDocs", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public ExternalDocumentation ExternalDocs { get; set; }
    }
}