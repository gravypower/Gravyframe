using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentService : Service<ContentRequest, ContentResponse>
    {
        private readonly IContentDao _contentDao;
        private readonly IContentConstants _contentConstants;

        //public ContentService()
        //{
        //}

        public ContentService(IContentDao contentDao, IContentConstants contentConstants)
        {
            _contentDao = contentDao;
            _contentConstants = contentConstants;
        }

        public override ContentResponse Get(ContentRequest request)
        {
            GardRequest(request);

            return CreateResponce(request);
        }

        private static void GardRequest(ContentRequest request)
        {
            if (request == null)
                throw new NullContentRequestException();
        }

        private ContentResponse CreateResponce(ContentRequest request)
        {
            var responce = ValidateRequest(request);

            if (!IsRequestASuccess(responce)) 
                return responce;

            PopulateContentById(responce, request);
            PopulateContentByCategoryId(responce, request);

            return responce;
        }


        private ContentResponse ValidateRequest(ContentRequest request)
        {
            var responce = new ContentResponse();
            if (IsContentIdValid(request))
            {
                if (IsCategoryIdValid(request))
                {
                    responce.ResponceCode = GravyResponceCodes.Failure;
                    responce.Errors.Add(_contentConstants.ContenIdError);
                    responce.Errors.Add(_contentConstants.ContenCategoryIdError);
                }
            }

            return responce;
        }

        private static bool IsCategoryIdValid(ContentRequest request)
        {
            return String.IsNullOrEmpty(request.CategoryId);
        }

        private static bool IsContentIdValid(ContentRequest request)
        {
            return String.IsNullOrEmpty(request.ContentId);
        }

        private static bool IsRequestASuccess(ContentResponse responce)
        {
            return responce.ResponceCode == GravyResponceCodes.Success;
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
