using System.Collections.Generic;
using Examine;
using Examine.LuceneEngine;
using Lucene.Net.Analysis;
using Lucene.Net.Store;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers.MockIndex
{
    public class MockedIndex
    {
        public ISearcher Searcher { get; set; }

        public IIndexer Indexer { get; set; }

        public Directory LuceneDir { get; set; }

        public ISimpleDataService SimpleDataService { get; set; }

        public MockIndexFieldList StandardFields { get; set; }

        public IIndexCriteria IndexCriteria { get; set; }

        public Analyzer Analyzer { get; set; }
        
        public MockIndexFieldList UserFields { get; set; }

        public IEnumerable<string> IndexTypes { get; set; }

        public IEnumerable<string> IncludeNodeTypes { get; set; }

        public IEnumerable<string> ExcludeNodeTypes { get; set; }

    }
}
