using NUnit.Framework;
using Gravyframe.Kernel.Umbraco.Tests.Examine;
using NSubstitute;
namespace Gravyframe.Data.Umbraco.Tests
{
    [TestFixture]
    public class ExampleExamineTests
    {
        private MockedIndex mockedIndex;

        private const string IndexType = "News";
        private const string IndexFeildName = "categoryId";


        [SetUp]
        public void SetUp()
        {
            this.mockedIndex = MockIndexFactory.GetMock(
                new MockIndexFieldList().AddIndexField("id", "Number", true),
                new MockIndexFieldList().AddIndexField(IndexFeildName),
                new[] { IndexType },
                new string[] { },
                new string[] { });

            var mockDataSet = new MockSimpleDataSet(IndexType)
                .AddData(1, IndexFeildName, "category1")
                .AddData(2, IndexFeildName, "category1")
                .AddData(3, IndexFeildName, "category2");

            mockedIndex.SimpleDataService.GetAllData("News").Returns(mockDataSet);

            mockedIndex.Indexer.RebuildIndex();

        }

        [Test]
        public void GetNewByCategory()
        {
            // Act
            var searchCriteria = mockedIndex.Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", "category1").Compile();
            var result = mockedIndex.Searcher.Search(query);

            // Assert
            Assert.IsTrue(result.TotalItemCount == 2);
        }

        [Test]
        public void GetNewByDifferentCategory()
        {
            // Act
            var searchCriteria = mockedIndex.Searcher.CreateSearchCriteria();
            var query = searchCriteria.Field("categoryId", "category2").Compile();
            var result = mockedIndex.Searcher.Search(query);

            // Assert
            Assert.IsTrue(result.TotalItemCount == 1);
        }
    }
}
