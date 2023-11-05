using System;
using System.Xml.XPath;
using AsyncApi.Core.Helper;

namespace AsyncApi.UI
{
    public class AsyncApiUiOptions
    {
        public readonly string Title;
        public readonly string Version;
        public XPathNavigator XmlNavigator;

        public AsyncApiUiOptions(string title, string version)
        {
            Title = title;
            Version = version;
        }

        public void IncludeXmlComments(string filePath)
        {
            IncludeXmlComments(() => new XPathDocument(filePath));
        }
        public void IncludeXmlComments(Func<XPathDocument> xmlDocFactory)
        {
            var xmlDoc = xmlDocFactory();
            XmlNavigator = xmlDoc.CreateNavigator();
        }
    }
}