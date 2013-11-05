namespace Gravyframe.Kernel.Umbraco.Tests.Examine.Helpers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using global::Examine;
    using global::Examine.LuceneEngine;

    public class MockSimpleDataSet : IEnumerable<SimpleDataSet>
    {
        private List<SimpleDataSet> ListOfSimpleData { get; set; }
        private string Type { get; set; }

        public MockSimpleDataSet(string type)
        {
            this.ListOfSimpleData = new List<SimpleDataSet>();
            this.Type = type;
        }

        public MockSimpleDataSet AddData(int id, string name, string value)
        {
            var simpleDataSet = this.ListOfSimpleData.SingleOrDefault(row => row.NodeDefinition.NodeId == id);
            if (simpleDataSet != null)
            {
                simpleDataSet.RowData.Add(name, value);
                return this;
            }

            var nodeDefinition = new IndexedNode { NodeId = id, Type = this.Type };

            var rowData = new Dictionary<string, string>
            {
                {name, value}
            };

            this.ListOfSimpleData.Add(
                new SimpleDataSet
                {
                    NodeDefinition = nodeDefinition,
                    RowData = rowData
                });
            return this;
        }


        public IEnumerator<SimpleDataSet> GetEnumerator()
        {
            return this.ListOfSimpleData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ListOfSimpleData.GetEnumerator();
        }
    }
}
