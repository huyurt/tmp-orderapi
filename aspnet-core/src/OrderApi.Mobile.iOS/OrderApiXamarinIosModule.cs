using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    [DependsOn(typeof(OrderApiXamarinSharedModule))]
    public class OrderApiXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiXamarinIosModule).GetAssembly());
        }
    }
}