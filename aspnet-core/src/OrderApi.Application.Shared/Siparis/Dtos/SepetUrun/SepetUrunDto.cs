using Abp.Application.Services.Dto;

namespace OrderApi.Siparis.Dtos.SepetUrun
{
    public class SepetUrunDto : EntityDto
    {
        public decimal Tutar { get; set; }

        public string Aciklama { get; set; }
        
        public int SepetId { get; set; }
    }
}