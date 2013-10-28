using Examine;
using Examine.LuceneEngine;
using Examine.LuceneEngine.Providers;
using Lucene.Net.Analysis.Standard;
using NSubstitute;
using Lucene.Net.Store;
using UmbracoExamine;
using System.Collections.Generic;
using System.Linq;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    public class MockIndexFactory
    {
        public static MockedIndex GetMock(
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
