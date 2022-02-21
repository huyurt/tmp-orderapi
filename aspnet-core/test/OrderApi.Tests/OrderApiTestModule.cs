using Abp.Modules;
using OrderApi.Test.Base;

namespace OrderApi.Tests
{
    [DependsOn(typeof(OrderApiTestBaseModule))]
    public class OrderApiTestModule : AbpModule
    {
       
    }
}
