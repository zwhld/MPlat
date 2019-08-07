using Microsoft.Extensions.Configuration;

namespace Camc.MES53.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
