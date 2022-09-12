using System;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    public class ExternalDocumentation
    {
        public ExternalDocumentation(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// A short description of the target documentation.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description")]
        public string Description { get; set; }
        
        /// <summary>
        /// The URL for the target documentation.
        /// Value MUST be in the format of a URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; }
    }
}