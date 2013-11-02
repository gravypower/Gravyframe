namespace Gravyframe.Configuration
{
    public abstract class NewsConfiguration : INewsConfiguration
    {
        public virtual string NewsIdError
        {
            get { return "News Id error"; }
        }

        public virtual string NewsCategoryIdError
        {
            get { return "News Category Id error"; }
        }

        public virtual int DefaultListSize
        {
            get { return 10; }
        }


        public virtual string NullNewsError
        {
            get { return "Null News error"; }
        }
    }
}

