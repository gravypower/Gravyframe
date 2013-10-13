using System.Collections.Generic;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using Gravyframe.Kernel.Umbraco.Tests;
using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.Tests
{
    [TestFixture]
    public class UmbracoNewsDaoTests : NewsDaoTests
    {
        private INode _newsConfigrationNode;
        private INodeFactoryFacade _nodeFactoryFacade;

        [SetUp]
        public void SetUp()
        {
            _newsConfigrationNode = Substitute.For<INode>();
            _nodeFactoryFacade = Substitute.For<INodeFactoryFacade>();

            Sut = new UmbracoNewsDao(_newsConfigrationNode, _nodeFactoryFacade);
        }

        [Test]
        public void SomeTest()
        {
            // Assign
            var node = MockNodeFactory.BuildNode(new Dictionary<string, object> {{"Body", "Test"}});
            _nodeFactoryFacade.GetNode(1).Returns(node);

            // Act
            var result = Sut.GetNews("1");

            // Assert
            Assert.AreEqual("Test", result.Body);
        }

        protected override string GetExampleId()
        {
            return "1";
        }
    }
}
