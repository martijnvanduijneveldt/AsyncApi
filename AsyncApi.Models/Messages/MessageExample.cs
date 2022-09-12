using YamlDotNet.Serialization;

namespace AsyncApi.Models.Messages
{
    public class MessageExample
    {
        /// <summary>
        /// A machine friendly name for the example.
        /// </summary>
        [YamlMember(Alias = "name", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Name { get; set; }

        /// <summary>
        /// A short summary of what the example is about.
        /// </summary>
        [YamlMember(Alias = "summary", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Summary { get; set; }

        /// <summary>
        /// Example of headers that will be included in the message.
        /// </summary>
        [YamlMember(Alias = "headers", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public object Headers { get; set; }

        /// <summary>
        /// Example message payload.
        /// </summary>
        [YamlMember(Alias = "payload", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public object Payload { get; set; }
    }
}