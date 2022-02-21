using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OrderApi.Authorization;

namespace OrderApi
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(OrderApiApplicationSharedModule),
        typeof(OrderApiCoreModule)
        )]
    public class OrderApiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiApplicationModule).GetAssembly());
        }
    }
}