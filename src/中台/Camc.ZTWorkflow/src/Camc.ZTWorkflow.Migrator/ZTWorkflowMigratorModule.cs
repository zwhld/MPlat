using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Camc.ZTWorkflow.Configuration;
using Camc.ZTWorkflow.EntityFrameworkCore;
using Camc.ZTWorkflow.Migrator.DependencyInjection;

namespace Camc.ZTWorkflow.Migrator
{
    [DependsOn(typeof(ZTWorkflowEntityFrameworkCoreModule))]
    public class ZTWorkflowMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ZTWorkflowMigratorModule(ZTWorkflowEntityFrameworkCoreModule ZTWorkflowEntityFrameworkCoreModule)
        {
            ZTWorkflowEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ZTWorkflowMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ZTWorkflowConsts.ConnectionStringName
                );
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZTWorkflowMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}