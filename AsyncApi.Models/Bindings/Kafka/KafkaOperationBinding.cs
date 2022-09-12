using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models.Bindings.Kafka
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/tree/master/kafka#Operation-binding-object
    /// </remarks>
    public class KafkaOperationBinding
    {
        /// <summary>
        /// Id of the consumer group.
        /// </summary>
        [YamlMember(Alias = "groupId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema GroupId { get; set; }

        /// <summary>
        /// Id of the consumer inside a consumer group.
        /// </summary>
        [YamlMember(Alias = "clientId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema ClientId { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}
