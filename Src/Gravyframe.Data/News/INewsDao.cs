namespace Gravyframe.Data.News
{
    public interface INewsDao
    {
        Models.News GetNews(string newsId);
    }
}
