using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings.Mqtt
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/blob/master/mqtt/README.md#server-binding-object
    /// </remarks>
    public class MqttServerBinding
    {
        /// <summary>
        /// The client identifier.
        /// </summary>
        [YamlMember(Alias = "clientId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string ClientId { get; set; }

        /// <summary>
        /// Whether to create a persistent connection or not. When false, the connection will be persistent.
        /// </summary>
        [YamlMember(Alias = "cleanSession", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? CleanSession { get; set; }

        /// <summary>
        /// Last Will and Testament configuration.
        /// </summary>
        [YamlMember(Alias = "lastWill", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public MqttServerBindingLastWill LastWill { get; set; }

        /// <summary>
        /// Interval in seconds of the longest period of time the broker and the client can endure without sending a message.
        /// </summary>
        [YamlMember(Alias = "keepAlive", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int? KeepAlive { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }

    public class MqttServerBindingLastWill
    {
        /// <summary>
        /// The topic where the Last Will and Testament message will be sent.
        /// </summary>
        [YamlMember(Alias = "topic", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Topic { get; set; }

        /// <summary>
        /// Defines how hard the broker/client will try to ensure that the Last Will and Testament message is received. Its value MUST be either 0, 1 or 2.
        /// </summary>
        [YamlMember(Alias = "qos", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public int? Qos { get; set; }

        /// <summary>
        /// Last Will message.
        /// </summary>
        [YamlMember(Alias = "message", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Message { get; set; }

        /// <summary>
        /// Whether the broker should retain the Last Will and Testament message or not.
        /// </summary>
        [YamlMember(Alias = "retain", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Retain { get; set; }
    }
}