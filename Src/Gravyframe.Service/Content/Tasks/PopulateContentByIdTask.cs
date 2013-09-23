using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content.Tasks
{
    public class PopulateContentByIdTask : ContentTask
    {
        public PopulateContentByIdTask(IContentDao contentDao, IContentConstants contentConstants) : base(contentDao, contentConstants)
        {
        }

        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            if (!String.IsNullOrEmpty(request.ContentId))
            {
                response.Content = ContentDao.GetContent();
                response.Code = ResponceCodes.Success;
            }
            else if(response.Code != ResponceCodes.Success)
            {
                response.Code = ResponceCodes.Failure;
                response.Errors.Add(ContentConstants.ContenCategoryIdError);
            }
        }
    }
}
