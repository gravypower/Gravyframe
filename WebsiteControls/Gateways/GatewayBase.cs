using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.MessageBase;
using WebsiteKernel;

namespace WebsiteControls.Gateways
{
    public abstract class GatewayBase<T>
    {

        protected readonly IItemIDService itemIDService;
        protected readonly IClientTagService clientTagService;

        protected GatewayBase(IItemIDService itemIDService, IClientTagService clientTagService)
        {
            Guard.IsNotNull(() => itemIDService);
            Guard.IsNotNull(() => clientTagService);


            this.itemIDService = itemIDService;
            this.clientTagService = clientTagService;

        }

        /// <summary>
        /// This method works out if the request is valid
        /// </summary>
        /// <param name="request">The request you sent to the service layer</param>
        /// <param name="response">The response you received back form the service layer</param>
        protected void Correlate(RequestBase<T> request, ResponseBase response)
        {
            if (request.RequestId != response.CorrelationId)
                throw new ApplicationException("RequestId and CorrelationId do not match.");
        }
    }
}