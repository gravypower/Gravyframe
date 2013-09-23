using System;
using System.Collections.Generic;
using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content.Tasks
{
    public class PopulateContentByIdTask : ContentTask
    {
        public PopulateContentByIdTask(IContentDao contentDao, IContentConstants contentConstants) : base(contentDao, contentConstants)
        {
        }

        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            response.Content = ContentDao.GetContent();
        }

        public override IEnumerable<string> ValidateResponse(ContentRequest request)
        {
            if (String.IsNullOrEmpty(request.ContentId))
                return new List<string>
                    {
                        ContentConstants.ContenCategoryIdError
                    };

            return new List<string>();
        }
    }
}
