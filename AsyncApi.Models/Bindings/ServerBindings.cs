using AsyncApi.Models.Bindings.Amqp;
using AsyncApi.Models.Bindings.Http;
using AsyncApi.Models.Bindings.Kafka;
using AsyncApi.Models.Bindings.Mqtt;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings
{
    /// <summary>
    /// ServerBindings can be either a the bindings or a reference to the bindings.
    /// </summary>
    public interface IServerBindings {}

    /// <summary>
    /// A reference to the OperationBindings within the AsyncAPI components.
    /// </summary>
    public class ServerBindingsReference : Reference, IServerBindings
    {
        public ServerBindingsReference(string id) : base(id, "#/components/serverBindings/{0}") { }
    }

    public class ServerBindings : IServerBindings
    {
        [YamlMember(Alias = "amqp", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpServerBinding Amqp { get; set; }

        [YamlMember(Alias = "http", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public HttpServerBinding Http { get; set; }

        [YamlMember(Alias = "kafka", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public KafkaServerBinding Kafka { get; set; }

        [YamlMember(Alias = "mqtt", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public MqttServerBinding Mqtt { get; set; }
    }
}