namespace Gravyframe.Service.News
{
    public interface INewsConstants
    {
        string NewsIdError { get; }
    }

    public class NewsConstants : INewsConstants
    {
        public string NewsIdError
        {
            get { return "News Id error"; }
        }
    }
}

