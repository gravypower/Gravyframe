﻿namespace Gravyframe.Configuration
{
    public class NewsConfiguration : INewsConfiguration
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
