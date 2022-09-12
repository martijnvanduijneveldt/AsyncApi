using AsyncApi.Models.Bindings.Amqp;
using AsyncApi.Models.Bindings.Http;
using AsyncApi.Models.Bindings.Kafka;
using AsyncApi.Models.Bindings.Mqtt;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings
{
    /// <summary>
    /// MessageBindings can be either a the bindings or a reference to the bindings.
    /// </summary>
    public interface IMessageBindings {}

    /// <summary>
    /// A reference to the MessageBindings within the AsyncAPI components.
    /// </summary>
    public class MessageBindingsReference : Reference, IMessageBindings
    {
        public MessageBindingsReference(string id) : base(id, "#/components/messageBindings/{0}") { }
    }

    public class MessageBindings : IMessageBindings
    {
        [YamlMember(Alias = "amqp", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpMessageBinding Amqp { get; set; }

        [YamlMember(Alias = "http", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public HttpMessageBinding Http { get; set; }

        [YamlMember(Alias = "kafka", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public KafkaMessageBinding Kafka { get; set; }

        [YamlMember(Alias = "mqtt", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public MqttMessageBinding Mqtt { get; set; }
    }
}