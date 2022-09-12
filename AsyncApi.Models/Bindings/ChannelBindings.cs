using AsyncApi.Models.Bindings.Amqp;
using AsyncApi.Models.Bindings.Http;
using AsyncApi.Models.Bindings.Kafka;
using AsyncApi.Models.Bindings.Mqtt;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings
{
    /// <summary>
    /// ChannelBindings can be either a the bindings or a reference to the bindings.
    /// </summary>
    public interface IChannelBindings {}

    /// <summary>
    /// A reference to the ChannelBindings within the AsyncAPI components.
    /// </summary>
    public class ChannelBindingsReference : Reference, IChannelBindings
    {
        public ChannelBindingsReference(string id) : base(id, "#/components/channelBindings/{0}") { }
    }

    public class ChannelBindings : IChannelBindings
    {
        [YamlMember(Alias = "amqp", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpChannelBinding Amqp { get; set; }

        [YamlMember(Alias = "http", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public HttpChannelBinding Http { get; set; }

        [YamlMember(Alias = "kafka", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public KafkaChannelBinding Kafka { get; set; }

        [YamlMember(Alias = "mqtt", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public MqttChannelBinding Mqtt { get; set; }
    }
}