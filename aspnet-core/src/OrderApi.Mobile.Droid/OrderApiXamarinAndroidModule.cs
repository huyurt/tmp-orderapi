using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    [DependsOn(typeof(OrderApiXamarinSharedModule))]
    public class OrderApiXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiXamarinAndroidModule).GetAssembly());
        }
    }
}