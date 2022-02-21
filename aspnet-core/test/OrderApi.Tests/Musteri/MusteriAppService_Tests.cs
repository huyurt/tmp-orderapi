using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using OrderApi.Musteri;
using OrderApi.Musteri.Dtos.Musteri;
using Shouldly;
using Xunit;

namespace OrderApi.Tests.Musteri
{
    public class MusteriAppService_Tests : AppTestBase
    {
        private readonly IMusteriAppService _musteriAppService;

        public MusteriAppService_Tests()
        {
            _musteriAppService = Resolve<IMusteriAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Musteri_Without_Any_Filter()
        {
            var dto = new CreateOrEditMusteriDto
            {
                Ad = "Hudayfe",
                Soyad = "Yurt",
            };
            
            await _musteriAppService.CreateOrEdit(dto);
            
            var musteriler = await _musteriAppService.GetAll(new GetAllMusteriInput());

            musteriler.TotalCount.ShouldBe(1);
        }
        
        [Fact]
        public async Task Should_Get_Musteri_With_Filter()
        {
            var dto = new CreateOrEditMusteriDto
            {
                Ad = "Hudayfe",
                Soyad = "Yurt",
            };
            
            await _musteriAppService.CreateOrEdit(dto);

            var musteriler = await _musteriAppService.GetAll(
                new GetAllMusteriInput
                {
                    Filter = "Hudayfe"
                });

            musteriler.TotalCount.ShouldBe(1);
            musteriler.Items[0].Musteri.Ad.ShouldBe("Hudayfe");
            musteriler.Items[0].Musteri.Soyad.ShouldBe("Yurt");
        }
        
        [Fact]
        public async Task Should_Create_Musteri_With_Valid_Arguments()
        {
            var dto = new CreateOrEditMusteriDto
            {
                Ad = "Hudayfe",
                Soyad = "Yurt",
                Sehir = "Ankara",
            };
            
            await _musteriAppService.CreateOrEdit(dto);

            UsingDbContext(
                context =>
                {
                    var musteri = context.Musteriler.FirstOrDefault(e => e.Ad == dto.Ad);
                    musteri.ShouldNotBe(null);
                    musteri.Ad.ShouldBe(dto.Ad);
                });
        }
        
        [Fact]
        public async Task Should_Not_Create_Musteri_With_Invalid_Arguments()
        {
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _musteriAppService.CreateOrEdit(
                        new CreateOrEditMusteriDto
                        {
                            Ad = "Hudayfe"
                        });
                });
        }
    }
}