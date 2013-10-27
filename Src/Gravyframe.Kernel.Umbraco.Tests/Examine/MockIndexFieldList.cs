using System.Collections.Generic;
using Examine;
using NSubstitute;

namespace Gravyframe.Kernel.Umbraco.Tests.Examine
{
    public class MockIndexFieldList : IEnumerable<IIndexField>
    {
        private List<IIndexField> IndexFieldList { get; set; }

        public MockIndexFieldList()
        {
            IndexFieldList = new List<IIndexField>();
        }

        public MockIndexFieldList AddIndexField(string name, bool enableSorting)
        {
            return AddIndexField(name, string.Empty, enableSorting);
        }

        public MockIndexFieldList AddIndexField(string name)
        {
            return AddIndexField(name, string.Empty);
        }

        public MockIndexFieldList AddIndexField(string name, string type, bool enableSorting = false)
        {
            var indexField = Substitute.For<IIndexField>();
            indexField.Name.Returns(name);
            indexField.EnableSorting.Returns(enableSorting);
            indexField.Type.Returns(type);

            IndexFieldList.Add(indexField);

            return this;
        }

        public IEnumerator<IIndexField> GetEnumerator()
        {
            return IndexFieldList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return IndexFieldList.GetEnumerator();
        }
    }
}
