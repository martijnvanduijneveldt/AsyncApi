using System;
using System.IO;
using System.Xml.XPath;
using NUnit.Framework;

namespace AsyncApi.Core.Tests
{
    public class AsyncApiBuilderTest
    {
        private XPathNavigator _comments;
        
        [OneTimeSetUp]
        public void Setup()
        {
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "AsyncApi.Core.Tests.xml");
            _comments = new XPathDocument(filePath).CreateNavigator();
        }
        
        [Test]
        public void TestBasicGeneration()
        {
            var builder = new AsyncApiBuilder(null);

            builder.AddInfo("myTitle", "1.0.1");

            var text = builder.Serialize();
            var refFile = ReferenceFileHelper.ReadFile("BasicGeneration.yml");
            
            Assert.That(text, Is.EqualTo(refFile), "File content should match");
        }

        [Test]
        public void TestBasicMethod()
        {
            
            var builder = new AsyncApiBuilder(_comments);

            builder.AddInfo("myTitle", "1.0.1");

            var method = typeof(AsyncApiBuilderTest).GetMethod(nameof(DummyMethodForTest));
            builder.AddServerMethod("/chat", method);
            
            var method2 = typeof(AsyncApiBuilderTest).GetMethod(nameof(DummyMethodForTest2));
            builder.AddServerMethod("/chat", method2);
            
            var text = builder.Serialize();

            var refFile = ReferenceFileHelper.ReadFile("BasicMethod.yml");
            Assert.That(text, Is.EqualTo(refFile), "File content should match");
        }

        /// <summary>
        /// My summary for DummyMethodForTest
        /// </summary>
        /// <param name="message">My description for message</param>
        /// <param name="number">My description for number</param>
        public void DummyMethodForTest(string message, int number)
        {   
        }
        
        /// <summary>
        /// My summary for DummyMethodForTest2
        /// </summary>
        /// <param name="message2">My description for message2</param>
        /// <param name="number2">My description for number2</param>
        public void DummyMethodForTest2(string message2, int number2)
        {   
        }
    }
}