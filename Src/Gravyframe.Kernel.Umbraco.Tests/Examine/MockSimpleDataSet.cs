using System.Collections;
using System.Collections.Generic;
using Examine;
using Examine.LuceneEngine;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    public class MockSimpleDataSet : IEnumerable<SimpleDataSet>
    {
        private List<SimpleDataSet> ListOfSimpleData { get; set; }
        private string Type { get; set; }

        public MockSimpleDataSet(string type)
        {
            ListOfSimpleData = new List<SimpleDataSet>();
            Type = type;
        }

        public MockSimpleDataSet AddData(int id, string name, string value)
        {
            var nodeDefinition = new IndexedNode {NodeId = id, Type = Type};

            var rowData = new Dictionary<string, string>
            {
                {name, value}
            };

            ListOfSimpleData.Add(
                new SimpleDataSet
                {
                    NodeDefinition = nodeDefinition,
                    RowData = rowData
                });
            return this;
        }


        public IEnumerator<SimpleDataSet> GetEnumerator()
        {
            return ListOfSimpleData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ListOfSimpleData.GetEnumerator();
        }
    }
}
