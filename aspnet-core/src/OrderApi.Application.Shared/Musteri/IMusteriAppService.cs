using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OrderApi.Musteri.Dtos.Musteri;

namespace OrderApi.Musteri
{
    public interface IMusteriAppService : IApplicationService
    {
        Task<PagedResultDto<GetMusteriForViewDto>> GetAll(GetAllMusteriInput input);

        Task<GetMusteriForViewDto> GetMusteriForView(EntityDto input);

        Task<GetMusteriForEditOutput> GetMusteriForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditMusteriDto input);

        Task Delete(EntityDto input);
    }
}