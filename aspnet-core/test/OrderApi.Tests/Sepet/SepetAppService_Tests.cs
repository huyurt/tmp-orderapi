using OrderApi.Siparis;

namespace OrderApi.Tests.Sepet
{
    public class SepetAppService_Tests : AppTestBase
    {
        private readonly ISepetAppService _sepetAppService;

        public SepetAppService_Tests()
        {
            _sepetAppService = Resolve<ISepetAppService>();
        }
    }
}