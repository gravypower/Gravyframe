namespace Gravyframe.Service.News
{
    public interface INewsConstants
    {
        string NewsIdError { get; }
        string NewsCategoryIdError { get; }
    }

    public class NewsConstants : INewsConstants
    {
        public string NewsIdError
        {
            get { return "News Id error"; }
        }

        public string NewsCategoryIdError
        {
            get { return "News Category Id error"; }
        }
    }
}

