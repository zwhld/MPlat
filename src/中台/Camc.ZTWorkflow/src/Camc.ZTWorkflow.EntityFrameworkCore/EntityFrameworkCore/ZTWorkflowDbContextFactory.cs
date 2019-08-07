using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Camc.ZTWorkflow.Configuration;
using Camc.ZTWorkflow.Web;

namespace Camc.ZTWorkflow.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ZTWorkflowDBContextFactory : IDesignTimeDbContextFactory<ZTWorkflowDBContext>
    {
        public ZTWorkflowDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZTWorkflowDBContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            ZTWorkflowDBContextConfigurer.Configure(builder, configuration.GetConnectionString(ZTWorkflowConsts.ConnectionStringName));

            return new ZTWorkflowDBContext(builder.Options);
        }
    }
}