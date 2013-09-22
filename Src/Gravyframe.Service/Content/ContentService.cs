using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentService : Service<ContentRequest, ContentResponse, ContentService.NullContentRequestException>
    {
        private readonly IContentDao _contentDao;
        private readonly IContentConstants _contentConstants;

        public ContentService(IContentDao contentDao, IContentConstants contentConstants)
        {
            _contentDao = contentDao;
            _contentConstants = contentConstants;
        }

        protected override ContentResponse CreateResponce(ContentRequest request)
        {
            var response = new ContentResponse();
            PopulateContentById(response, request);
            PopulateContentByCategoryId(response, request);

            return response;
        }

        protected override ContentResponse ValidateRequest(ContentRequest request)
        {
            var responce = new ContentResponse();
            if (!request.IsRequestValid())
            {
                responce.Code = ResponceCodes.Failure;
                responce.Errors.Add(_contentConstants.ContenIdError);
                responce.Errors.Add(_contentConstants.ContenCategoryIdError);
            }

            return responce;
        }

        private void PopulateContentById(ContentResponse responce, ContentRequest request)
        {
            if (IsContentRequestedById(request))
            {
                responce.Content = _contentDao.GetContent();
            }
        }

        private static bool IsContentRequestedById(ContentRequest request)
        {
            return !String.IsNullOrEmpty(request.ContentId);
        }

        private void PopulateContentByCategoryId(ContentResponse responce, ContentRequest request)
        {
            if (IsContentRequestedByCategoryId(request))
            {
                responce.ContentList = _contentDao.GetContentByCategory(request.CategoryId);
            }
        }

        private static bool IsContentRequestedByCategoryId(ContentRequest request)
        {
            return !String.IsNullOrEmpty(request.CategoryId);
        }

        [Serializable]
        public class NullContentRequestException : NullRequestException
        {
        }
    }
}
