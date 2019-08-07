using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.ZTWorkflow
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(ZTWorkflowCoreModule)
        )]
    public class ZTWorkflowApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
          

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZTWorkflowApplicationModule).GetAssembly());
        }
    }
}