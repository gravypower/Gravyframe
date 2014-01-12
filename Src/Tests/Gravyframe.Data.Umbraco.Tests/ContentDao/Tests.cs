namespace Gravyframe.Data.Umbraco.Tests.ContentDao
{
    using Gravyframe.Data.Tests.ContentDao;
    using Gravyframe.Data.Umbraco.Content;
    using Gravyframe.Kernel.Umbraco.Facades;
    using Gravyframe.Models.Umbraco;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class Tests: Tests<UmbracoContent>
    {
        public INodeFactoryFacade NodeFactoryFacade;

        [SetUp]
        public void SetUp()
        {
            this.NodeFactoryFacade = Substitute.For<INodeFactoryFacade>();
            Sut = new ContentDao(NodeFactoryFacade);
        }

        protected override string GetExampleCategoryId()
        {
            return "ExampleCategoryId";
        }

        protected override string GetExampleId()
        {
            return "ExampleId";
        }
    }
}
