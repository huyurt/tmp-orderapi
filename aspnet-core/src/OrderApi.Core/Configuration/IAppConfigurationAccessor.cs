using Microsoft.Extensions.Configuration;

namespace OrderApi.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
