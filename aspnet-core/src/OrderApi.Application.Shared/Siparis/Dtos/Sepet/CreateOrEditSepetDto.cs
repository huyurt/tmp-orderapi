using System.Collections.Generic;
using Abp.Application.Services.Dto;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis.Dtos.Sepet
{
    public class CreateOrEditSepetDto : EntityDto<int?>
    {
        public int MusteriId { get; set; }

        public List<CreateOrEditSepetUrunDto> SepetUrunler { get; set; }
    }
}