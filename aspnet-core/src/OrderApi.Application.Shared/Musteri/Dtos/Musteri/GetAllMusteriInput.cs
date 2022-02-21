using Abp.Application.Services.Dto;

namespace OrderApi.Musteri.Dtos.Musteri
{
    public class GetAllMusteriInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}