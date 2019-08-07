using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.ZTWorkflow.Startup
{
    [DependsOn(typeof(ZTWorkflowCoreModule))]
    public class ZTWorkflowGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZTWorkflowGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}