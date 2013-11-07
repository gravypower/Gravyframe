﻿namespace Gravyframe.Service.Tests.ContentService
{
    using System.Collections.Generic;
    using Gravyframe.Configuration;
    using Gravyframe.Data.Content;
    using Gravyframe.Service.Content;
    using Gravyframe.Service.Content.Tasks;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class Tests : ServiceTests<ContentRequest, ContentResponse, ContentService, ContentService.NullContentRequestException>
    {
        public ContentDao<Models.Content> Dao;
        public IContentConfiguration ContentConfiguration;
        public IResponseHydrogenationTaskList<ContentRequest, ContentResponse> ResponseHydrogenationTasks;
        protected override void ServiceSetUp()
        {
            this.Dao = Substitute.For<ContentDao<Models.Content>>();
            this.ContentConfiguration = new ContentConfiguration();

            this.ResponseHydrogenationTasks = Substitute.For<IResponseHydrogenationTaskList<ContentRequest, ContentResponse>>();

            this.ResponseHydrogenationTasks.GetEnumerator().Returns(
                new List<ResponseHydrator<ContentRequest, ContentResponse>>
                {
                    new PopulateContentByCategoryIdResponseHydrator(this.Dao, this.ContentConfiguration),
                    new PopulateContentByIdResponseHydrator(this.Dao, this.ContentConfiguration)
                }.GetEnumerator());

            this.Sut = new Gravyframe.Service.Content.ContentService(this.ResponseHydrogenationTasks);
        }
    }
}
