using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.ServiceContracts;
using Service.Messages;
using Service.MessageBase;

namespace Service.ServiceImplementations
{
    public abstract class Service<T> : IService
    {
        protected string accessToken;

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public Messages.TokenResponse GetToken(Messages.TokenRequest request)
        {
            var response = new TokenResponse(request.RequestId);

            // Validate client tag only
            if (!ValidRequest(request, response, Validate.ClientTag))
                return response;

            // Note: these are session based and expire when session expires.
            accessToken = Guid.NewGuid().ToString();

            response.AccessToken = accessToken;
            return response;
        }

        /// <summary>
        /// Valids the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <param name="validate">The validate.</param>
        /// <returns></returns>
        protected bool ValidRequest(RequestBase request, ResponseBase response, Validate validate)
        {
            // Validate Client Tag. 
            // Hardcoded here. In production this should query a 'client' table in a database.
            if ((Validate.ClientTag & validate) == Validate.ClientTag)
            {
                if (!ClientTags.Default.TagList.Contains(request.ClientTag))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Unknown Client Tag";
                    return false;
                }
            }

            // Validate access token
            if ((Validate.AccessToken & validate) == Validate.AccessToken)
            {
                if (request.AccessToken != accessToken)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Invalid or expired AccessToken. Call GetToken()";
                    return false;
                }
            }

            //need to think about this as sitecore usually deals with this

            // Validate user credentials
            //if ((Validate.UserCredentials & validate) == Validate.UserCredentials)
            //{
            //    if (_userName == null)
            //    {
            //        response.Acknowledge = AcknowledgeType.Failure;
            //        response.Message = "Please login and provide user credentials before accessing these methods.";
            //        return false;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Validation options enum. Used in validation of messages.
        /// </summary>
        [Flags]
        protected enum Validate
        {
            ClientTag = 0x0001,
            AccessToken = 0x0002,
            UserCredentials = 0x0004,
            All = ClientTag | AccessToken | UserCredentials
        }


    }
}
