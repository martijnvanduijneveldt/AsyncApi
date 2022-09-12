using AsyncApi.Models.Bindings.Amqp;
using AsyncApi.Models.Bindings.Http;
using AsyncApi.Models.Bindings.Kafka;
using AsyncApi.Models.Bindings.Mqtt;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Bindings
{
    /// <summary>
    /// OperationBindings can be either a the bindings or a reference to the bindings.
    /// </summary>
    public interface IOperationBindings {}

    /// <summary>
    /// A reference to the OperationBindings within the AsyncAPI components.
    /// </summary>
    public class OperationBindingsReference : Reference, IOperationBindings
    {
        public OperationBindingsReference(string id) : base(id, "#/components/operationBindings/{0}") { }
    }

    public class OperationBindings : IOperationBindings
    {         
        [YamlMember(Alias = "http", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public HttpOperationBinding Http { get; set; }

        [YamlMember(Alias = "amqp", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public AmqpOperationBinding Amqp { get; set; }

        [YamlMember(Alias = "kafka", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public KafkaOperationBinding Kafka { get; set; }

        [YamlMember(Alias = "mqtt", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public MqttOperationBinding Mqtt { get; set; }
    }
}