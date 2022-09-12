using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings.Amqp
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/blob/master/amqp/README.md#message-binding-object
    /// </remarks>
    public class AmqpMessageBinding
    {
        /// <summary>
        /// A MIME encoding for the message content.
        /// </summary>
        [YamlMember(Alias = "contentEncoding", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Application-specific message type.
        /// </summary>
        [YamlMember(Alias = "messageType", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string MessageType { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}