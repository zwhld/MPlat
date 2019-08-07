using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Camc.MES53.Startup
{
    [DependsOn(typeof(MES53CoreModule))]
    public class MES53GraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53GraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}