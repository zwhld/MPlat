using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Camc.MES53.Configuration;
using Camc.MES53.Web;

namespace Camc.MES53.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MES53DbContextFactory : IDesignTimeDbContextFactory<MES53DbContext>
    {
        public MES53DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MES53DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            MES53DbContextConfigurer.Configure(builder, configuration.GetConnectionString(MES53Consts.ConnectionStringName));

            return new MES53DbContext(builder.Options);
        }
    }
}