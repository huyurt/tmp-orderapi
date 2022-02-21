using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis;

public class SepetUrunAppService : OrderApiAppServiceBase, ISepetUrunAppService
{
    private readonly IRepository<SepetUrun> _sepetUrunRepository;

    public SepetUrunAppService(
        IRepository<SepetUrun> sepetUrunRepository
    )
    {
        _sepetUrunRepository = sepetUrunRepository;
    }

    public async Task<PagedResultDto<GetSepetUrunForViewDto>> GetAll(GetAllSepetUrunInput input)
    {
        var queryable = _sepetUrunRepository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                e => e.Aciklama.ToUpper().Contains(input.Filter.ToUpper()));
        
        var pagedAndFiltered = queryable
            .OrderBy(input.Sorting ?? "id desc")
            .PageBy(input);

        var result = from entity in pagedAndFiltered

            select new GetSepetUrunForViewDto
            {
                SepetUrun = ObjectMapper.Map<SepetUrunDto>(entity),
            };

        var totalCount = await queryable.CountAsync();

        return new PagedResultDto<GetSepetUrunForViewDto>(
            totalCount,
            await result.ToListAsync()
        );
    }

    public async Task<GetSepetUrunForViewDto> GetSepetUrunForView(EntityDto input)
    {
        var entity = await _sepetUrunRepository.GetAsync(input.Id);

        var output = new GetSepetUrunForViewDto
        {
            SepetUrun = ObjectMapper.Map<SepetUrunDto>(entity),
        };

        return output;
    }

    public async Task<GetSepetUrunForEditOutput> GetSepetUrunForEdit(EntityDto input)
    {
        var output = await _sepetUrunRepository.GetAll()
            .Where(e => e.Id == input.Id)
            .Select(entity => new GetSepetUrunForEditOutput
            {
                SepetUrun = ObjectMapper.Map<CreateOrEditSepetUrunDto>(entity),
            }).FirstOrDefaultAsync();

        return output;
    }

    public async Task CreateOrEdit(CreateOrEditSepetUrunDto input)
    {
        if (input.Id.HasValue)
        {
            await Update(input);
        }
        else
        {
            await Create(input);
        }
    }

    private async Task Create(CreateOrEditSepetUrunDto input)
    {
        var entity = ObjectMapper.Map<SepetUrun>(input);
        
        await _sepetUrunRepository.InsertAsync(entity);
    }

    private async Task Update(CreateOrEditSepetUrunDto input)
    {
        var entity = await _sepetUrunRepository.FirstOrDefaultAsync(input.Id.Value);

        ObjectMapper.Map(input, entity);
    }

    public async Task Delete(EntityDto input)
    {
        await _sepetUrunRepository.DeleteAsync(input.Id);
    }
}