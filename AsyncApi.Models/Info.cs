using System;
using YamlDotNet.Serialization;

namespace AsyncApi.Models {
    public class Info
    {
        public Info(string title, string version)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Version = version ?? throw new ArgumentNullException(nameof(version));
        }

        /// <summary>
        /// The title of the application.
        /// </summary>
        [YamlMember(Alias = "title", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Title { get; }

        /// <summary>
        /// Provides the version of the application API
        /// (not to be confused with the specification version).
        /// </summary>
        [YamlMember(Alias = "version", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Version { get; }

        /// <summary>
        /// A short description of the application.
        /// CommonMark syntax can be used for rich text representation.
        /// </summary>
        [YamlMember(Alias = "description", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string Description { get; set; }

        /// <summary>
        /// A URL to the Terms of Service for the API
        /// MUST be in the format of a URL.
        /// </summary>
        [YamlMember(Alias = "termsOfService", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public string TermsOfService { get; set; }

        /// <summary>
        /// The contact information for the exposed API.
        /// </summary>
        [YamlMember(Alias = "contact", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public Contact Contact { get; set; }

        /// <summary>
        /// The license information for the exposed API.
        /// </summary>
        [YamlMember(Alias = "license", DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        public License License { get; set; }
    }
    
    public class Contact
    {
        /// <summary>
        /// The identifying name of the contact person/organization.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL pointing to the contact information.
        /// MUST be in the format of a URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The email address of the contact person/organization.
        /// MUST be in the format of an email address.
        /// </summary>
        [YamlMember(Alias = "email")]
        public string Email { get; set; }
    }
    
    public class License
    {
        public License(string name)
        {
            Name = name;
        }
        
        /// <summary>
        /// The license name used for the API.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; }

        /// <summary>
        /// A URL to the license used for the API.
        /// MUST be in the format of a URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; set; }
    }
}