using System.Collections.Generic;
using OrderApi.Musteri.Dtos.Musteri;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis.Dtos.Sepet
{
    public class GetSepetForViewDto
    {
        public SepetDto Sepet { get; set; }
        
        public MusteriDto Musteri { get; set; }

        public List<SepetUrunDto> SepetUrunler { get; set; }
    }
}