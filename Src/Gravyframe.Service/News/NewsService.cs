using System;

namespace Gravyframe.Service.News
{
    public class NewsService
    {
        public object Get(object request)
        {
            if (request == null)
                throw new NullNewsRequestException();

            return new object();
            ;
        }


        [Serializable]
        public class NullNewsRequestException : ArgumentNullException
        {
        }
    }
}
