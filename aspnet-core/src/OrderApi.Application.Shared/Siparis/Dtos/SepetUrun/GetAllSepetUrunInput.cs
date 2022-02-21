using Abp.Application.Services.Dto;

namespace OrderApi.Siparis.Dtos.SepetUrun
{
    public class GetAllSepetUrunInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}