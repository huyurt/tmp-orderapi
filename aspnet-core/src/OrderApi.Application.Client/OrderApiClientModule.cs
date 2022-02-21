using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    public class OrderApiClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiClientModule).GetAssembly());
        }
    }
}
