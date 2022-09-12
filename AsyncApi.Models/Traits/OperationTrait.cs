using System.Collections.Generic;
using AsyncApi.Models.Bindings;
using Saunter.AsyncApiSchema.v2;
using YamlDotNet.Serialization;

namespace AsyncApi.Models.Traits
{
    /// <summary>
    /// Can be either an <see cref="OperationTrait"/> or an <see cref="OperationTraitReference"/> reference to an operation trait.
    /// </summary>
    public interface IOperationTrait { }
    
    /// <summary>
    /// A reference to an OperationTrait within the AsyncAPI components.
    /// </summary>
    public class OperationTraitReference : Reference, IOperationTrait
    {
        public OperationTraitReference(string id) : base(id, "#/components/operationTraits/{0}") { }
    }
    
    public class OperationTrait : IOperationTrait
    {
        /// <summary>
        /// Unique string used to identify the operation.
        /// The id MUST be unique among all operations described in the API.
        /// The operationId value is case-sensitive.
        /// Tools and libraries MAY use the operationId to uniquely identify an operation,
        /// therefore, it is RECOMMENDED to follow common programming naming conventions.
        /// </summary>
        [YamlMember(Alias = "operationId", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string OperationId { get; set; }

        /// <summary>
        /// A short summary of what the operation is about.
        /// </summary>
        [YamlMember(Alias = "summary", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Summary { get; set; }

        /// <summary>
        /// A verbose explanation of the operation.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// A list of tags for API documentation control. Tags can be used for logical grouping of operations.
        /// </summary>
        [YamlMember(Alias = "tags", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public ISet<Tag> Tags { get; set; }

        /// <summary>
        /// Additional external documentation for this operation.
        /// </summary>
        [YamlMember(Alias = "externalDocs", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public ExternalDocumentation ExternalDocs { get; set; }

        /// <summary>
        /// A free-form map where the keys describe the name of the protocol and the values describe protocol-specific definitions for the operation.
        /// </summary>
        [YamlMember(Alias = "bindings", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public IOperationBindings Bindings { get; set; }
    }
}