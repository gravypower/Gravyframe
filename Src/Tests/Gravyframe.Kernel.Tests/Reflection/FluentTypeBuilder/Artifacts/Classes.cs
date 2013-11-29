namespace Gravyframe.Kernel.Tests.Reflection.FluentTypeBuilder.Artifacts
{
    public class TestType
    {
        public string PassThroughString { get; set; }
        public TestType()
        { }

        public TestType(string one)
        {
            this.PassThroughString = one;
        }
    }
}
