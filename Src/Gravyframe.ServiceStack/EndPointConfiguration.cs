namespace Gravyframe.ServiceStack
{
    public class EndPointConfiguration
    {
        public bool AutomaticServiceWiringEnabled { get; set; }

        public EndPointConfiguration()
        {
            AutomaticServiceWiringEnabled = true;
        }
    }
}
