namespace Gravyframe.Data.InMemory.Tests.InMemoryContentDao
{
    using Gravyframe.Data.InMemory.Content;
    using Gravyframe.Data.Tests;
    using Gravyframe.Data.Tests.ContentDao;

    using NUnit.Framework;

    [TestFixture]
    public class Tests : Tests<Models.Content>
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut = new InMemoryContentDao();
        }

        protected override string GetExampleCategoryId()
        {
            return "categoryId";
        }

        protected override string GetExampleId()
        {
            return "1";
        }
    }
}
