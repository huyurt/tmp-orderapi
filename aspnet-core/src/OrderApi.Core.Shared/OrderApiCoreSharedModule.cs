using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    public class OrderApiCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiCoreSharedModule).GetAssembly());
        }
    }
}