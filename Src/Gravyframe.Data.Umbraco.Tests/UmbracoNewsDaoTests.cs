using Gravyframe.Data.Tests;
using Gravyframe.Data.Umbraco.News;
using NUnit.Framework;

namespace Gravyframe.Data.Umbraco.Tests
{
    public class UmbracoNewsDaoTests : NewsDaoTests
    {
        [SetUp]
        public void SetUp()
        {
            Sut = new UmbracoNewsDao();
        }
    }
}
