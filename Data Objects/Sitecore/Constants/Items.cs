using Sitecore.Data;

namespace DataObjects.Sitecore.Constants
{
    public class Items
    {
        private static readonly ID articleBucket = new ID("{F6B393BD-3726-4BFD-859F-7293CB1095B6}");
        public static ID ArticleBucket
        {
            get { return articleBucket; }
        }
    }
}
