using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Gravyframe.Service.Messages;

namespace Gravyframe.Service.Content
{
    public class ContentService
    {
        public ContentResponse Get(ContentRequest request)
        {
            GardRequest(request);

            var responce = CreateResponce(request);

            return responce;
        }

        private static ContentResponse CreateResponce(ContentRequest request)
        {
            if (!IsContentIdValid(request))
            {
                return BuildInvalidContentIdResponce();
            }

            return new ContentResponse();
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

        private static bool IsContentIdValid(ContentRequest request)
        {
            return !String.IsNullOrEmpty(request.ContentId);
        }

        private static void GardRequest(ContentRequest request)
        {
            if (request == null)
                throw new NullContentRequestException();
        }

        [Serializable]
        public class NullContentRequestException : Exception
        {
        }
    }
}
