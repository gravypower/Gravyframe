namespace Gravyframe.ServiceStack
{
    using System;

    public interface IAutomaticServiceWiringConfigurationStrategy : IConfigurationStrategy
    {
        Type GetServiceType();
    }
}
