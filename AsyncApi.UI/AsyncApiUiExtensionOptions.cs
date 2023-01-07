using System;
using System.Xml.XPath;
using AsyncApi.Core.Helper;

namespace AsyncApi.UI
{
    public class AsyncApiUiOptions
    {
        public XPathNavigator XmlNavigator;

        public AsyncApiUiOptions()
        {
            
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