namespace Gravyframe.Kernel.Umbraco.Tests.TestHelpers.Examine.MockIndex
{
    using System.Collections.Generic;

    using global::Examine;
    using global::Examine.LuceneEngine;

    using Lucene.Net.Analysis;
    using Lucene.Net.Store;

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
