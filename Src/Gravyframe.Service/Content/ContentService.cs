using System;
using Gravyframe.Data.Content;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentService
    {
        private readonly IContentDao _contentDao;

        public ContentService(IContentDao contentDao)
        {
            _contentDao = contentDao;
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
                    responce.Acknowledge = AcknowledgeType.Failure;
                    responce.Errors.Add(ContentConstants.ContenIdError);
                    responce.Errors.Add(ContentConstants.ContenCategoryIdError);
                }
            }

            if(responce.Acknowledge == AcknowledgeType.Success)
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

        public class NullContentRequestException : Exception
        {
        }
    }
}
