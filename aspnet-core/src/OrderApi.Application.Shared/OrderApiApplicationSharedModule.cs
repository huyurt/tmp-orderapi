using Abp.FluentValidation;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    [DependsOn(
        typeof(OrderApiCoreSharedModule),
        typeof(AbpFluentValidationModule)
        )]
    public class OrderApiApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiApplicationSharedModule).GetAssembly());
        }
    }
}