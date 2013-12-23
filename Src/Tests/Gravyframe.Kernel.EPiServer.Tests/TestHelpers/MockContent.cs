namespace Gravyframe.Kernel.EPiServer.Tests.TestHelpers
{
    using global::EPiServer.Core;

    using NSubstitute;

    public class MockContent
    {
        public IContent Mock()
        {
            var content = Substitute.For<IContent>();
            return content;
        }
    }
}
