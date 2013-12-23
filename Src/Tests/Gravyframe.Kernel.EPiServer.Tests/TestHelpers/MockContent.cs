namespace Gravyframe.Kernel.EPiServer.Tests.TestHelpers
{
    using System;
    using System.Collections.Generic;

    using global::EPiServer.Core;

    using NSubstitute;

    public class MockContent
    {
        private readonly IDictionary<string, object> properties;

        public MockContent()
        {
            properties = new Dictionary<string, object>();
        }

        public IContent Mock(Guid id)
        {
            var content = Substitute.For<IContent>();

            var propertyDataCollection = new PropertyDataCollection();
            content.Property.Returns(propertyDataCollection);

            foreach (var pair in properties)
            {
                var property = Substitute.For<PropertyData>();

                property.Name = pair.Key;
                property.Value.Returns(pair.Value);

                propertyDataCollection.Add(property);
            }

            content.ContentGuid.Returns(id);

            return content;
        }

        public MockContent AddProperty(string alias, object value)
        {
            properties.Add(alias, value);
            return this;
        }
    }
}
