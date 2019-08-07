using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Camc.MES53.Configuration;
using Camc.MES53.EntityFrameworkCore;
using Camc.MES53.Migrator.DependencyInjection;

namespace Camc.MES53.Migrator
{
    [DependsOn(typeof(MES53EntityFrameworkCoreModule))]
    public class MES53MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MES53MigratorModule(MES53EntityFrameworkCoreModule MES53EntityFrameworkCoreModule)
        {
            MES53EntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MES53MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MES53Consts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(MES53MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}