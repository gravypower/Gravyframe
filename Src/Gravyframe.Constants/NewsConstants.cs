namespace Gravyframe.Constants
{
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

        public int DefaultListSize
        {
            get { return 10; }
        }
    }
}

