using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models.Bindings.Kafka
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/tree/master/kafka#Message-binding-object
    /// </remarks>
    public class KafkaMessageBinding
    {
        /// <summary>
        /// The message key.
        /// </summary>
        [YamlMember(Alias = "key", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema Key { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}
