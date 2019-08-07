using Abp;
using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Camc.ZTWorkflow.Configuration;
using Camc.ZTWorkflow.Migrations.Seed;

namespace Camc.ZTWorkflow.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(ZTWorkflowCoreModule),
        typeof(AbpZeroCoreIdentityServerEntityFrameworkCoreModule)
        )]
    public class ZTWorkflowEntityFrameworkCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ZTWorkflowDBContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ZTWorkflowDBContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
						var configurationAccessor = IocManager.Resolve<IAppConfigurationAccessor>();
						//ZTWorkflowDBContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
						ZTWorkflowDBContextConfigurer.Configure(options.DbContextOptions, configurationAccessor.Configuration["ConnectionStrings:ZTCostDB"]);
						//todo 如何读取连接字符串？？
						//ZTWorkflowDBContextConfigurer.Configure(options.DbContextOptions, "Server=localhost; Database=ZTWorkflowDB; Trusted_Connection=True;");
					}
                });
            }

            // Uncomment below line to write change logs for the entities below:
            //Configuration.EntityHistory.Selectors.Add("ZTWorkflowEntities", EntityHistoryHelper.TrackedTypes);
            //Configuration.CustomConfigProviders.Add(new EntityHistoryConfigProvider(Configuration));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZTWorkflowEntityFrameworkCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            var configurationAccessor = IocManager.Resolve<IAppConfigurationAccessor>();

            using (var scope = IocManager.CreateScope())
            {
                if (!SkipDbSeed && scope.Resolve<DatabaseCheckHelper>().Exist(configurationAccessor.Configuration["ConnectionStrings:ZTWorkflowDB"]))
                {
                    SeedHelper.SeedHostDb(IocManager);
                }
            }
        }
    }
}
