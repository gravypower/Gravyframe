using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content.Tasks
{
    public class PopulateContentByCategoryIdTask : ContentTask
    {
        public PopulateContentByCategoryIdTask(IContentDao contentDao, IContentConstants contentConstants) : base(contentDao, contentConstants)
        {
        }

        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            if (!String.IsNullOrEmpty(request.CategoryId))
            {
                response.ContentList = ContentDao.GetContentByCategory(request.CategoryId);
                response.Code = ResponceCodes.Success;
            }
            else if (response.Code != ResponceCodes.Success)
            {
                response.Code = ResponceCodes.Failure;
                response.Errors.Add(ContentConstants.ContenIdError);   
            }
        }
    }
}
