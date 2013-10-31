namespace Gravyframe.Configuration
{
    public interface INewsConfiguration
    {
        string NewsIdError { get; }
        string NewsCategoryIdError { get; }
        int DefaultListSize { get; }
    }
}