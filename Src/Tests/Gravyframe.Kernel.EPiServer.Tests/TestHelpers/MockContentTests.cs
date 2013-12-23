namespace Gravyframe.Kernel.EPiServer.Tests.TestHelpers
{
    using NUnit.Framework;

    [TestFixture]
    public class MockContentTests
    {
        public MockContent Sut;

        [Test]
        public void CanMockContent()
        {
            var content = Sut.Mock();
        }
    }
}
