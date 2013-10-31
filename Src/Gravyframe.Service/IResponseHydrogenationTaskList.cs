using Gravyframe.Service.Messages;
using System.Collections.Generic;

namespace Gravyframe.Service
{
    public interface IResponseHydrogenationTaskList<TRequest, TResponse> : IEnumerable<ResponseHydrator<TRequest, TResponse>>
        where TRequest : Request
        where TResponse : Response
    {
    }
}
