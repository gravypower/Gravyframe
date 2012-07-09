using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.MessageBase;

namespace SitecoreClient.Repositories
{
    public abstract class RepositoryBase
    {
        protected void Correlate(RequestBase request, ResponseBase response)
        {
            if (request.RequestId != response.CorrelationId)
                throw new ApplicationException("RequestId and CorrelationId do not match.");
        }
    }
}