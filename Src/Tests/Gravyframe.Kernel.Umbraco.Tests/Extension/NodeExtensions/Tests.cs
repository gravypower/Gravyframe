﻿namespace Gravyframe.Kernel.Umbraco.Tests.Extension.NodeExtensions
{
    using Gravyframe.Kernel.Umbraco.Extension;
    using Gravyframe.Kernel.Umbraco.Tests.TestHelpers;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanFindParent()
        {
            var mockedParent = new MockNode().AddNodeTypeAlias("parent").Mock(10);

            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            var result = mockedNode.FindNodeUpTree("parent");

            Assert.AreEqual(result, mockedParent);
        }

        [Test]
        public void CanFindGrandParent()
        {
            var mockedGrandParent = new MockNode().AddNodeTypeAlias("grandparent").Mock(2);

            var mockedParent = new MockNode().AddNodeTypeAlias("parent").AddParent(mockedGrandParent).Mock(10);

            var mockedNode = new MockNode().AddNodeTypeAlias("test").AddParent(mockedParent).Mock(90);

            var result = mockedNode.FindNodeUpTree("grandparent");

            Assert.AreEqual(result, mockedGrandParent);
        }

        [Test]
        public void CantFindParentReturnsNull()
        {
            var mockedNode = new MockNode().AddNodeTypeAlias("test").Mock(90);

            var result = mockedNode.FindNodeUpTree("testParent");

            Assert.IsNull(result);
        }
    }
}