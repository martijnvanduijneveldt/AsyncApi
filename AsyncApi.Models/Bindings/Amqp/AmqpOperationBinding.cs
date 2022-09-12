using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings.Amqp
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/blob/master/amqp/README.md#operation-binding-object
    /// </remarks>
    public class AmqpOperationBinding
    {
        /// <summary>
        /// TTL (Time-To-Live) for the message. It MUST be greater than or equal to zero.
        /// </summary>
        [YamlMember(Alias = "expiration", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int Expiration { get; set; }

        /// <summary>
        /// Identifies the user who has sent the message.
        /// </summary>
        [YamlMember(Alias = "userId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string UserId { get; set; }

        /// <summary>
        /// The routing keys the message should be routed to at the time of publishing.
        /// </summary>
        [YamlMember(Alias = "cc", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IList<string> Cc { get; set; }

        /// <summary>
        /// A priority for the message.
        /// </summary>
        [YamlMember(Alias = "priority", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int Priority { get; set; }

        /// <summary>
        /// Delivery mode of the message. Its value MUST be either 1 (transient) or 2 (persistent).
        /// </summary>
        [YamlMember(Alias = "deliveryMode", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int DeliveryMode { get; set; }

        /// <summary>
        /// Whether the message is mandatory or not.
        /// </summary>
        [YamlMember(Alias = "mandatory", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Mandatory { get; set; }

        /// <summary>
        /// Like cc but consumers will not receive this information.
        /// </summary>
        [YamlMember(Alias = "bcc", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IList<string> Bcc { get; set; }

        /// <summary>
        /// Name of the queue where the consumer should send the response.
        /// </summary>
        [YamlMember(Alias = "replyTo", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string ReplyTo { get; set; }

        /// <summary>
        /// Whether the message should include a timestamp or not.
        /// </summary>
        [YamlMember(Alias = "timestamp", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Timestamp { get; set; }

        /// <summary>
        /// Whether the consumer should ack the message or not.
        /// </summary>
        [YamlMember(Alias = "ack", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Ack { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}