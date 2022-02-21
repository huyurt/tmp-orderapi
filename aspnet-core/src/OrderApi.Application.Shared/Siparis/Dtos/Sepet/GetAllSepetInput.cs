using Abp.Application.Services.Dto;

namespace OrderApi.Siparis.Dtos.Sepet
{
    public class GetAllSepetInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}