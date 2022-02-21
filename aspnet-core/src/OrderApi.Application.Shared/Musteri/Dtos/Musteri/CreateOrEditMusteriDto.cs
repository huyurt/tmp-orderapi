using Abp.Application.Services.Dto;

namespace OrderApi.Musteri.Dtos.Musteri
{
    public class CreateOrEditMusteriDto : EntityDto<int?>
    {
        public string Ad { get; set; }
        
        public string Soyad { get; set; }
        
        public string Sehir { get; set; }
    }
}