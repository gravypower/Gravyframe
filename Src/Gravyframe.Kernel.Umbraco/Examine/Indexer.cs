// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indexer.cs" company="Gravypowered">
//   Copyright 2013 Aaron Job
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the Indexer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gravyframe.Kernel.Umbraco.Examine
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using global::Examine;

    using Gravyframe.Kernel.Umbraco.Extension;
    using Gravyframe.Kernel.Umbraco.Facades;

    using Lucene.Net.Analysis;

    using UmbracoExamine;
    using UmbracoExamine.DataServices;

    using Directory = Lucene.Net.Store.Directory;

    /// <summary>
    /// The indexer.
    /// </summary>
    public class Indexer : BaseUmbracoIndexer
    {
        private readonly INodeFactoryFacade nodeFactoryFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="Indexer"/> class.
        /// </summary>
        public Indexer()
        {
            this.nodeFactoryFacade = new NodeFactoryFacade();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Indexer"/> class.
        /// </summary>
        /// <param name="indexerData">
        /// The indexer data.
        /// </param>
        /// <param name="indexPath">
        /// The index path.
        /// </param>
        /// <param name="dataService">
        /// The data service.
        /// </param>
        /// <param name="analyzer">
        /// The analyzer.
        /// </param>
        /// <param name="async">
        /// The async.
        /// </param>
        public Indexer(
            IIndexCriteria indexerData,
            DirectoryInfo indexPath,
            IDataService dataService,
            Analyzer analyzer,
            bool async)
            : base(indexerData, indexPath, dataService, analyzer, async)
        {
            this.nodeFactoryFacade = new NodeFactoryFacade();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Indexer"/> class.
        /// </summary>
        /// <param name="indexerData">
        /// The indexer data.
        /// </param>
        /// <param name="luceneDirectory">
        /// The lucene directory.
        /// </param>
        /// <param name="dataService">
        /// The data service.
        /// </param>
        /// <param name="analyzer">
        /// The analyzer.
        /// </param>
        /// <param name="async">
        /// The async.
        /// </param>
        /// <param name="nodeFactoryFacade">
        /// The node factory facade.
        /// </param>
        public Indexer(
            IIndexCriteria indexerData,
            Directory luceneDirectory,
            IDataService dataService,
            Analyzer analyzer,
            bool async,
            INodeFactoryFacade nodeFactoryFacade)
            : base(indexerData, luceneDirectory, dataService, analyzer, async)
        {
            this.nodeFactoryFacade = nodeFactoryFacade;
        }

        /// <summary>
        /// Gets the supported types.
        /// </summary>
        /// <value>
        /// The supported types.
        /// </value>
        protected override IEnumerable<string> SupportedTypes
        {
            get
            {
                return new[] { IndexTypes.Content };
            }
        }

        /// <summary>
        /// The on gathering node data.
        /// </summary>
        /// <param name="e">
        /// The IndexingNodeDataEventArgs.
        /// </param>
        protected override void OnGatheringNodeData(IndexingNodeDataEventArgs e)
        {
            var currentNode = this.nodeFactoryFacade.GetNode(e.NodeId);
            var siteNode = currentNode.FindNodeUpTree("Site");
            if (siteNode != null && siteNode.Id != -1)
            {
                e.Fields.Add("site", siteNode.UrlName);
            }

            var categoriesNode = e.Node.Descendants("categories").SingleOrDefault();
            if (categoriesNode != null)
            {
                e.Fields.Add("categories", ReplaceCommasWithPipes(categoriesNode));
            }
        }

        private static string ReplaceCommasWithPipes(XElement categoriesNode)
        {
            return categoriesNode.Value.Replace(',', '|');
        }
    }
}
