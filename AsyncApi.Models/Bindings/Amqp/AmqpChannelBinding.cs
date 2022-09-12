using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings.Amqp
{
    /// <remarks>
    /// https://github.com/asyncapi/bindings/blob/master/amqp/README.md#channel
    /// </remarks>
    public class AmqpChannelBinding
    {
        /// <summary>
        /// Defines what type of channel is it. Can be either queue or routingKey (default).
        /// </summary>
        [YamlMember(Alias = "is", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpChannelBindingIs? Is { get; set; }

        /// <summary>
        /// When is=routingKey, this object defines the exchange properties.
        /// </summary>
        [YamlMember(Alias = "exchange", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpChannelBindingExchange Exchange { get; set; }

        /// <summary>
        /// When is=queue, this object defines the queue properties.
        /// </summary>
        [YamlMember(Alias = "queue", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpChannelBindingQueue Queue { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }

    public class AmqpChannelBindingExchange
    {
        /// <summary>
        /// The name of the exchange. It MUST NOT exceed 255 characters long.
        /// </summary>
        [YamlMember(Alias = "name", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Name { get; set; }

        /// <summary>
        /// The type of the exchange. Can be either topic, direct, fanout, default or headers.
        /// </summary>
        [YamlMember(Alias = "type", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpChannelBindingExchangeType? Type { get; set; }

        /// <summary>
        /// Whether the exchange should survive broker restarts or not.
        /// </summary>
        [YamlMember(Alias = "durable", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Durable { get; set; }

        /// <summary>
        /// Whether the exchange should be deleted when the last queue is unbound from it.
        /// </summary>
        [YamlMember(Alias = "autoDelete", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? AutoDelete { get; set; }

        /// <summary>
        /// The virtual host of the exchange. Defaults to /.
        /// </summary>
        [YamlMember(Alias = "vhost", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string VirtualHost { get; set; }
    }

    public class AmqpChannelBindingQueue
    {
        /// <summary>
        /// The name of the queue. It MUST NOT exceed 255 characters long.
        /// </summary>
        [YamlMember(Alias = "name", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Name { get; set; }

        /// <summary>
        /// Whether the queue should survive broker restarts or not.
        /// </summary>
        [YamlMember(Alias = "durable", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Durable { get; set; }

        /// <summary>
        /// Whether the queue should be used only by one connection or not.
        /// </summary>
        [YamlMember(Alias = "exclusive", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? Exclusive { get; set; }

        /// <summary>
        /// Whether the queue should be deleted when the last consumer unsubscribes.
        /// </summary>
        [YamlMember(Alias = "autoDelete", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public bool? AutoDelete { get; set; }

        /// <summary>
        /// The virtual host of the queue. Defaults to /.
        /// </summary>
        [YamlMember(Alias = "vhost", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string VirtualHost { get; set; }
    }

    public enum AmqpChannelBindingIs
    {
        [EnumMember(Value = "routingKey")]
        RoutingKey,

        [EnumMember(Value = "queue")]
        Queue,
    }

    public enum AmqpChannelBindingExchangeType
    {
        [EnumMember(Value = "topic")]
        Topic,

        [EnumMember(Value = "direct")]
        Direct,

        [EnumMember(Value = "fanout")]
        Fanout,

        [EnumMember(Value = "default")]
        Default,

        [EnumMember(Value = "headers")]
        Headers,
    }
}