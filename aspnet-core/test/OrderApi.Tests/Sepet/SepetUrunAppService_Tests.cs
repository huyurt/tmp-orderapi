using OrderApi.Siparis;

namespace OrderApi.Tests.Sepet
{
    public class SepetUrunAppService_Tests : AppTestBase
    {
        private readonly ISepetUrunAppService _sepetUrunAppService;

        public SepetUrunAppService_Tests()
        {
            _sepetUrunAppService = Resolve<ISepetUrunAppService>();
        }
    }
}