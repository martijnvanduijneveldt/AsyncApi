using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings.Mqtt
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/blob/master/mqtt/README.md#operation-binding-object
    /// </remarks>
    public class MqttOperationBinding
    {
        /// <summary>
        /// Defines the Quality of Service (QoS) levels for the message flow between client and server.
        /// Its value MUST be either 0 (At most once delivery), 1 (At least once delivery), or 2 (Exactly once delivery).
        /// </summary>
        [YamlMember(Alias = "qos", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int? Qos { get; set; }

        /// <summary>
        /// Whether the broker should retain the message or not.
        /// </summary>
        [YamlMember(Alias = "retain", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Retain { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}