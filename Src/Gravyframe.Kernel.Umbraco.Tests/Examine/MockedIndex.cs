using Examine;
using Examine.LuceneEngine;
using Lucene.Net.Store;
using System.Collections.Generic;
using Lucene.Net.Analysis;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    public class MockedIndex
    {
        public ISearcher Searcher { get; set; }

        public IIndexer Indexer { get; set; }

        public ISimpleDataService SimpleDataService { get; set; }

        public Directory LuceneDir { get; set; }

        public MockIndexFieldList StandardFields { get; set; }

        public IIndexCriteria IndexCriteria { get; set; }

        public Analyzer Analyzer { get; set; }
        
        public MockIndexFieldList UserFields { get; set; }

        public IEnumerable<string> IndexTypes { get; set; }

        public IEnumerable<string> IncludeNodeTypes { get; set; }

        public IEnumerable<string> ExcludeNodeTypes { get; set; }

    }
}
