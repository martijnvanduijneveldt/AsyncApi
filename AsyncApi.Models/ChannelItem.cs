using System.Collections.Generic;
using AsyncApi.Models.Bindings;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    /// <summary>
    /// Describes the operations available on a single channel.
    /// </summary>
    public class ChannelItem
    {
        /// <summary>
        /// An optional description of this channel item.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// A definition of the SUBSCRIBE operation.
        /// </summary>
        [YamlMember(Alias = "subscribe", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public Operation Subscribe { get; set; }

        /// <summary>
        /// A definition of the PUBLISH operation.
        /// </summary>
        [YamlMember(Alias = "publish", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public Operation Publish { get; set; }

        /// <summary>
        /// A map of the parameters included in the channel name.
        /// It SHOULD be present only when using channels with expressions
        /// (as defined by RFC 6570 section 2.2).
        /// </summary>
        [YamlMember(Alias = "parameters", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public IDictionary<string, IParameter> Parameters { get; set; } = new Dictionary<string, IParameter>();

        /// <summary>
        /// A free-form map where the keys describe the name of the protocol
        /// and the values describe protocol-specific definitions for the channel.
        /// </summary>
        [YamlMember(Alias = "bindings", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IChannelBindings Bindings { get; set; }

        /// <summary>
        /// The servers on which this channel is available, specified as an optional unordered
        /// list of names (string keys) of Server Objects defined in the Servers Object (a map).
        /// If servers is absent or empty then this channel must be available on all servers
        /// defined in the Servers Object.
        /// </summary>
        [YamlMember(Alias = "servers", DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections)]
        public List<string> Servers { get; set; } = new List<string>();

        public bool ShouldSerializeParameters()
        {
            return Parameters != null && Parameters.Count > 0;
        }

        public bool ShouldSerializeServers()
        {
            return Servers != null && Servers.Count > 0;
        }
    }
}