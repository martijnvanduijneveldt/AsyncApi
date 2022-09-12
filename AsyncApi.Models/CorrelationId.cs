using System;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    /// <summary>
    /// Can be either a <see cref="CorrelationId"/> or a <see cref="Reference"/> to a CorrelationId.
    /// </summary>
    public interface ICorrelationId { }
    
    /// <summary>
    /// A reference to a CorrelationId within the AsyncAPI components.
    /// </summary>
    public class CorrelationIdReference : Reference, ICorrelationId
    {
        public CorrelationIdReference(string id) : base(id, "#/components/correlationIds/{0}") { }
    }
    

    public class CorrelationId : ICorrelationId
    {
        public CorrelationId(string location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        /// <summary>
        /// An optional description of the identifier.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        /// <summary>
        /// A runtime expression that specifies the location of the correlation ID.
        /// </summary>
        [YamlMember(Alias = "location")]
        public string Location { get; }

    }
}