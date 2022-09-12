using System;
using AsyncApi.SignalR;
using NUnit.Framework;

namespace AsyncApi.Core.Tests
{
    public class AsyncApiBuilderTest
    {
        [Test]
        public void TestBasicGeneration()
        {
            var builder = new AsyncApiBuilder();

            builder.AddInfo("myTitle", "1.0.1");

            var text = builder.Serialize();
            var refFile = ReferenceFileHelper.ReadFile("BasicGeneration.yml");
            
            Assert.That(text, Is.EqualTo(refFile), "File content should match");
        }

        [Test]
        public void TestBasicMethod()
        {
            var builder = new AsyncApiBuilder();

            builder.AddInfo("myTitle", "1.0.1");

            var method = typeof(AsyncApiBuilderTest).GetMethod(nameof(DummyMethodForTest));
            builder.AddPublicMethod("/chat", method);
            
            var text = builder.Serialize();

            var refFile = ReferenceFileHelper.ReadFile("BasicMethod.yml");
            Assert.That(text, Is.EqualTo(refFile), "File content should match");
        }

        public void DummyMethodForTest(string message, int number)
        {
            
        }
    }
}