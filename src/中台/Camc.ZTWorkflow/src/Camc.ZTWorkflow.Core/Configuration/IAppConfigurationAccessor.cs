using Microsoft.Extensions.Configuration;

namespace Camc.ZTWorkflow.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
