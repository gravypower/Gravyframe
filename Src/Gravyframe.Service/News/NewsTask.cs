namespace Gravyframe.Service.News
{
    public abstract class NewsTask : Task<NewsRequest, NewsResponse>
    {
        protected readonly INewsConstants NewsConstants;

        protected NewsTask(INewsConstants newsConstants)
        {
            NewsConstants = newsConstants;
        }
    }
}
