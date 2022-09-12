using System;
using System.Collections.Generic;
using AsyncApi.Models.Bindings;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    public class Server
    {
        public Server(string url, string protocol)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
        }

        /// <summary>
        /// A URL to the target host.
        /// This URL supports Server Variables and MAY be relative, to indicate that the host
        /// location is relative to the location where the AsyncAPI document is being served.
        /// Variable substitutions will be made when a variable is named in { brackets }.
        /// </summary>
        [YamlMember(Alias = "url", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Url { get; }

        /// <summary>
        /// The protocol this URL supports for connection.
        /// Supported protocol include, but are not limited to: amqp, amqps, http, https,
        /// jms, kafka, kafka-secure, mqtt, secure-mqtt, stomp, stomps, ws, wss.
        /// </summary>
        [YamlMember(Alias = "protocol", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Protocol { get; }

        /// <summary>
        /// The version of the protocol used for connection.
        /// For instance: AMQP 0.9.1, HTTP 2.0, Kafka 1.0.0, etc.
        /// </summary>
        [YamlMember(Alias = "protocolVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string ProtocolVersion { get; set; }

        /// <summary>
        /// An optional string describing the host designated by the URL.
        /// CommonMark syntax MAY be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// A map between a variable name and its value.
        /// The value is used for substitution in the server's URL template.
        /// </summary>
        [YamlMember(Alias = "variables", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IDictionary<string, ServerVariable> Variables { get; set; }

        /// <summary>
        /// A declaration of which security mechanisms can be used with this server.
        /// The list of values includes alternative security requirement objects
        /// that can be used. Only one of the security requirement objects need to
        /// be satisfied to authorize a connection or operation.
        /// </summary>
        [YamlMember(Alias = "security", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IList<Dictionary<string, List<string>>> Security { get; set; }

        /// <summary>
        /// A free-form map where the keys describe the name of the protocol and the
        /// values describe protocol-specific definitions for the server.
        /// </summary>
        [YamlMember(Alias = "bindings", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IServerBindings Bindings { get; set; }
    }
    
    public class ServerVariable
    {
        /// <summary>
        /// An enumeration of string values to be used if the substitution options are from a limited set.
        /// </summary>
        [YamlMember(Alias = "enum", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IList<string> Enum { get; set; }

        /// <summary>
        /// The default value to use for substitution, and to send, if an alternate value is not supplied.
        /// </summary>
        [YamlMember(Alias = "default", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Default { get; set; }

        /// <summary>
        /// An optional description for the server variable.
        /// CommonMark syntax MAY be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// An array of examples of the server variable.
        /// </summary>
        [YamlMember(Alias = "examples", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IList<string> Examples { get; set; }
    }

    public static class ServerProtocol
    {
        public const string Amqp = "amqp";

        public const string Amqps = "amqps";

        public const string Http = "http";

        public const string Https = "https";

        public const string Jms = "jms";

        public const string Kafka = "kafka";

        public const string KafkaSecure = "kafka-secure";

        public const string Mqtt = "mqtt";

        public const string SecureMqtt = "secure-mqtt";

        public const string Stomp = "stomp";

        public const string Stomps = "stomps";

        public const string Ws = "ws";

        public const string Wss = "wss";
    }
}