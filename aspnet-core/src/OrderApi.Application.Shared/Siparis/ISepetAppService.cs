using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OrderApi.Siparis.Dtos.Sepet;

namespace OrderApi.Siparis
{
    public interface ISepetAppService : IApplicationService
    {
        Task<PagedResultDto<GetSepetForViewDto>> GetAll(GetAllSepetInput input);

        Task<GetSepetForViewDto> GetSepetForView(EntityDto input);

        Task<GetSepetForEditOutput> GetSepetForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSepetDto input);

        Task Delete(EntityDto input);
    }
}