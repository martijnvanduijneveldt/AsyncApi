using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Messages
{
    public class Messages
    {
        [YamlMember(Alias = "oneOf")]
        public List<MessageReference> OneOf { get; set; } = new List<MessageReference>();
    }
}