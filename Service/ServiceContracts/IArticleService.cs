using System;
using System.Linq;
using System.ServiceModel;
using Service.Messages;

namespace Service.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IArticleService
    {
        [OperationContract]
        TokenResponse GetToken(TokenRequest request);

        [OperationContract]
        ArticleResponse GetArticles(ArticleRequest request);
    }
}
