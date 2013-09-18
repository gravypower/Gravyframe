using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentService
    {
        private readonly IContentDao _contentDao;
        private readonly IContentConstants _contentConstants;

        public ContentService(IContentDao contentDao, IContentConstants contentConstants)
        {
            _contentDao = contentDao;
            _contentConstants = contentConstants;
        }

        public ContentResponse Get(ContentRequest request)
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
            var responce = new ContentResponse();

            if (IsContentIdValid(request))
            {
                if (IsCategoryIfValid(request))
                {
                    responce.ResponceCode = GravyResponceCodes.Failure;
                    responce.Errors.Add(_contentConstants.ContenIdError);
                    responce.Errors.Add(_contentConstants.ContenCategoryIdError);
                }
            }

            if(responce.ResponceCode == GravyResponceCodes.Success)
            {
                responce.Content = _contentDao.GetContent();
            }


            return responce;
        }

        private static bool IsCategoryIfValid(ContentRequest request)
        {
            return String.IsNullOrEmpty(request.CategoryId);
        }

        private static bool IsContentIdValid(ContentRequest request)
        {
            return String.IsNullOrEmpty(request.ContentId);
        }

        [Serializable]
        public class NullContentRequestException : Exception
        {
        }
    }
}
