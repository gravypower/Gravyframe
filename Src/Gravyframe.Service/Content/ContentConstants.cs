namespace Gravyframe.Service.Content
{
    public interface IContentConstants
    {
        string ContenIdError { get;}
        string ContenCategoryIdError { get;}
    }

    public class ContentConstants : IContentConstants
    {
        public string ContenIdError
        {
            get { return "Content Id error"; }
        }

        public string ContenCategoryIdError
        {
            get { return "Content Category Id error"; }
        }
    }
}
