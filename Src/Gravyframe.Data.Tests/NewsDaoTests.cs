using Gravyframe.Data.News;
using NSubstitute;
using NUnit.Framework;

namespace Gravyframe.Data.Tests
{
    [TestFixture]
    public class NewsDaoTests
    {
        public INewsDao Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = Substitute.For<NewsDao>();
        }
    }
}
