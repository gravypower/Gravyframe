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
            if (!IsContentIdValid(request))
            {
                return BuildInvalidContentIdResponce();
            }

            return new ContentResponse
                {
                    Content = _contentDao.GetContent()
                };
        }

        private static bool IsContentIdValid(ContentRequest request)
        {
            return !String.IsNullOrEmpty(request.ContentId);
        }

        private static ContentResponse BuildInvalidContentIdResponce()
        {
            var responce = new ContentResponse
                {
                    Acknowledge = AcknowledgeType.Failure
                };

            responce.Errors.Add(ContentConstants.ContenIdError);

            return responce;
        }

        public class NullContentRequestException : Exception
        {
        }
    }
}
