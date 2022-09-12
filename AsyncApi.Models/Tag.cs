using System;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; }

        /// <summary>
        /// A short description for the tag. CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Additional external documentation for this tag.
        /// </summary>
        [YamlMember(Alias = "externalDocs")]
        public ExternalDocumentation ExternalDocs { get; set; }

        public static implicit operator Tag(string s)
        {
            return new Tag(s);
        }
    }
}