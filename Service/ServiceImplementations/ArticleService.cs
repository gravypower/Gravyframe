using System;
using System.Linq;
using Service.ServiceContracts;
using Service.Messages;
using System.ServiceModel;
using Service.MessageBase;
using DataObjects;
using WebsiteKernel;
using Service.Mappers;

namespace Service.ServiceImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ArticleService: IArticleService
    {
        private readonly IArticleDao articleDao;
        private readonly IDataTransferObjectsMapper dataTransferObjectsMapper;

        public ArticleService(IArticleDao articleDao, IDataTransferObjectsMapper dataTransferObjectsMapper)
        {
            //check that what was injected is not null.
            Guard.IsNotNull(() => articleDao);
            Guard.IsNotNull(() => dataTransferObjectsMapper);

            this.articleDao = articleDao;
            this.dataTransferObjectsMapper = dataTransferObjectsMapper;
        }

        private string accessToken;

        public TokenResponse GetToken(TokenRequest request)
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

        public ArticleResponse GetArticles(ArticleRequest request)
        {
            var response = new ArticleResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (request.LoadOptions.Contains("Comments"))
            {
                throw new NotImplementedException();
            }

            if (request.LoadOptions.Contains("Articles"))
            {
                var articles = articleDao.GetArticles();
                response.Articles = dataTransferObjectsMapper.ToDataTransferObjects(articles);
            }

            if (request.LoadOptions.Contains("Article"))
            {
                throw new NotImplementedException();
            }

            if (request.LoadOptions.Contains("Search"))
            {
                throw new NotImplementedException();
            }

            return response;
        }


        /// <summary>
        /// Validate 3 security levels for a request: ClientTag, AccessToken, and User Credentials
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="response">The response message.</param>
        /// <param name="validate">The validation that needs to take place.</param>
        /// <returns></returns>
        private bool ValidRequest(RequestBase request, ResponseBase response, Validate validate)
        {
            // Validate Client Tag. 
            // Hardcoded here. In production this should query a 'client' table in a database.
            if ((Validate.ClientTag & validate) == Validate.ClientTag)
            {
                if (request.ClientTag != "ABC123")
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
        private enum Validate
        {
            ClientTag = 0x0001,
            AccessToken = 0x0002,
            UserCredentials = 0x0004,
            All = ClientTag | AccessToken | UserCredentials
        }
    }
}
