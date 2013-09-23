using Gravyframe.Service.Messages;

namespace Gravyframe.Service
{
    public abstract class Task<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        public abstract void PopulateResponse(TRequest request, TResponse response);
    }
}
