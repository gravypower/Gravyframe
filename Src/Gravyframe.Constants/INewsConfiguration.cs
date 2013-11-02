namespace Gravyframe.Configuration
{
    public interface INewsConfiguration
    {
        string NewsIdError { get; }
        string NewsCategoryIdError { get; }
        string NullNewsError { get; }
        int DefaultListSize { get; }
    }
}