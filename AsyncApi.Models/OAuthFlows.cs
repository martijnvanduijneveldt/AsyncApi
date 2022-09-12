using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AsyncApi.Models
{
    public class OAuthFlows
    {
        [YamlMember(Alias = "implicit")]
        public OAuthFlow Implicit { get; set; }

        [YamlMember(Alias = "password")]
        public OAuthFlow Password { get; set; }

        [YamlMember(Alias = "clientCredentials")]
        public OAuthFlow ClientCredentials { get; set; }

        [YamlMember(Alias = "authorizationCode")]
        public OAuthFlow AuthorizationCode { get; set; }
    }
    
    public class OAuthFlow
    {
        [YamlMember(Alias = "authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [YamlMember(Alias = "tokenUrl")]
        public string TokenUrl { get; set; }

        [YamlMember(Alias = "refreshUrl")]
        public string RefreshUrl { get; set; }

        [YamlMember(Alias = "scopes")]
        public IDictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
    }
}