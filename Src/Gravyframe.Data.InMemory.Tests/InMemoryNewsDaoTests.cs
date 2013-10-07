﻿using Gravyframe.Constants;
using Gravyframe.Data.InMemory.News;
using Gravyframe.Data.Tests;
using NUnit.Framework;

namespace Gravyframe.Data.InMemory.Tests
{
    [TestFixture]
    public class InMemoryNewsDaoTests : NewsDaoTests
    {
        private INewsConstants _newsConstants;

        [SetUp]
        public void Setp()
        {
            _newsConstants = new NewsConstants();
            Sut = new InMemoryNewsDao(_newsConstants);
        }
    }
}