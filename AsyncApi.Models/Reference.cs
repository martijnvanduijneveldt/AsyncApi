using System;
using YamlDotNet.Serialization;

namespace Saunter.AsyncApiSchema.v2
{
    /// <summary>
    /// A reference to some other object within the AsyncAPI document. 
    /// </summary>
    public class Reference
    {
        public Reference(string id, string path)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id));
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        private readonly string _id;
        private readonly string _path;

        [YamlMember(Alias = "$ref")]
        public string Ref => string.Format(_path, _id);
        
        [YamlIgnore]
        public string Id => _id;
    }
}