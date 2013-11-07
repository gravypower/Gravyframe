namespace Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Examine;
    using global::Examine.LuceneEngine;
    using global::Examine.LuceneEngine.Providers;

    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Store;

    using NSubstitute;

    using UmbracoExamine;

    public class MockIndexFactory
    {
        public static MockedIndex GetSimpleDataServiceMock(
            MockIndexFieldList standardFields,
            MockIndexFieldList userFields,
            IEnumerable<string> indexTypes,
            IEnumerable<string> includeNodeTypes,
            IEnumerable<string> excludeNodeTypes)
        {
            var index = new MockedIndex
                                  {
                                      StandardFields = standardFields,
                                      UserFields = userFields,
                                      IncludeNodeTypes = includeNodeTypes.ToArray(),
                                      ExcludeNodeTypes = excludeNodeTypes.ToArray(),
                                      SimpleDataService = Substitute.For<ISimpleDataService>(),
                                      LuceneDir = new RAMDirectory()
                                  };

            index.IndexCriteria = new IndexCriteria(standardFields, userFields, index.IncludeNodeTypes, index.ExcludeNodeTypes, -1);

            index.Analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            index.Indexer = new SimpleDataIndexer(index.IndexCriteria, index.LuceneDir, index.Analyzer, index.SimpleDataService, indexTypes, false);

            index.Searcher = new UmbracoExamineSearcher(index.LuceneDir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));

            return index;
        }
    }
}
