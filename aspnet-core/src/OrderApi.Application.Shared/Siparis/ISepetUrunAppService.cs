using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis
{
    public interface ISepetUrunAppService : IApplicationService
    {
        Task<PagedResultDto<GetSepetUrunForViewDto>> GetAll(GetAllSepetUrunInput input);

        Task<GetSepetUrunForViewDto> GetSepetUrunForView(EntityDto input);

        Task<GetSepetUrunForEditOutput> GetSepetUrunForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSepetUrunDto input);

        Task Delete(EntityDto input);
    }
}