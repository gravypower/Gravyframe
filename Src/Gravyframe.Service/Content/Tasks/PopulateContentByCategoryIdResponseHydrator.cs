using System;
using System.Collections.Generic;
using Gravyframe.Configuration;
using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content.Tasks
{
    public class PopulateContentByCategoryIdResponseHydrator : ContentResponseHydrator
    {
        public PopulateContentByCategoryIdResponseHydrator(ContentDao<Models.Content> contentDao, IContentConfiguration contentConfiguration) : base(contentDao, contentConfiguration)
        {
        }

        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            response.ContentList = ContentDao.GetContentByCategory(request.CategoryId);         
        }

        public override IEnumerable<string> ValidateResponse(ContentRequest request)
        {
            if (String.IsNullOrEmpty(request.CategoryId))
                return new List<string>
                    {
                        ContentConfiguration.ContentIdError
                    };

            return new List<string>();
        }
    }
}
