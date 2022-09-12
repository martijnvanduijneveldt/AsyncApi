using YamlDotNet.Serialization;
using YamlDotNet.Serialization.Schemas;

namespace AsyncApi.Models.Bindings.Http
{
    /// <remarks>
    /// See: https://github.com/asyncapi/bindings/tree/master/http#message-binding-object
    /// </remarks>
    public class HttpMessageBinding
    {
        /// <summary>
        /// A Schema object containing the definitions for HTTP-specific headers.
        /// This schema MUST be of type object and have a properties key.
        /// </summary>
        [YamlMember(Alias = "headers", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public JsonSchema Headers { get; set; }

        /// <summary>
        /// The version of this binding. If omitted, "latest" MUST be assumed.
        /// </summary>
        [YamlMember(Alias = "bindingVersion", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string BindingVersion { get; set; }
    }
}
