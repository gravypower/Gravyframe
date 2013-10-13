using System.Collections.Generic;
using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using Gravyframe.Kernel.Umbraco;
using NSubstitute;
using NUnit.Framework;
using umbraco.interfaces;

namespace Gravyframe.Data.Umbraco.Tests
{
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
        public void someTest()
        {
            // Assign
            var newsID = 1;
            //_nodeFactoryFacade.GetNode(1).Returns(new Node())
            //Sut.GetNews()
        }
    }
}
