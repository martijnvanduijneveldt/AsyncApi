using Saunter.AsyncApiSchema.v2;

namespace AsyncApi.Models.Messages
{
    /// <summary>
    /// A reference to a Message within the AsyncAPI components.
    /// </summary>
    public class MessageReference : Reference
    {
        public MessageReference(string id) : base(id, "#/components/messages/{0}") { }
    }
}