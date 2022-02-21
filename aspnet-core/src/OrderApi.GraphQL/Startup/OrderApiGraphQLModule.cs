using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi.Startup
{
    [DependsOn(typeof(OrderApiCoreModule))]
    public class OrderApiGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}