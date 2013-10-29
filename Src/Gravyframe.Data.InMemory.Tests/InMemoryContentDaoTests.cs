using System.Linq;
using Gravyframe.Data.InMemory.Content;
using NUnit.Framework;

namespace Gravyframe.Data.InMemory.Tests
{
    using Gravyframe.Data.Tests;

    [TestFixture]
    public class InMemoryContentDaoTests : ContentDaoTests<Models.Content>
    {
        [SetUp]
        public void SetUp()
        {
            Sut = new InMemoryContentDao();
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
