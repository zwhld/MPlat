using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Camc.MES53.Authorization;
using Camc.MES53.Friendships;
using Camc.ZTCost.Application.Shared.MaterialsOutCost;
using Camc.ZTCost.Application.Smulate.MaterialsCost;
using Castle.MicroKernel.Registration;
using System;
using System.Reflection;

namespace Camc.MES53
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(MES53CoreModule)
        )]
    public class MES53ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);

			//注册中台服务拦截
			MidPlatServiceInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
		}

		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(typeof(MES53ApplicationModule).GetAssembly());
			//IocManager.RegisterAssemblyByConvention(typeof(ZTCost.Application.Smulate.MaterialsCost.MaterialsOutCostAppService).GetAssembly());
			var a = TypeMixer<object>.ExtendWith<IMaterialsOutCostAppService>();
			
			IocManager.IocContainer.Kernel.Register(Component.For<IMaterialsOutCostAppService>().Instance((IMaterialsOutCostAppService)a));
			//new DynamicClass();	
		}

    }
}