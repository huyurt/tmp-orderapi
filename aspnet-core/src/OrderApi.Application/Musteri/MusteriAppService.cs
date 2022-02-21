using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using OrderApi.Musteri.Dtos.Musteri;

namespace OrderApi.Musteri;

public class MusteriAppService : OrderApiAppServiceBase, IMusteriAppService
{
    private readonly IRepository<Musteri, int> _musteriRepository;

    public MusteriAppService(
        IRepository<Musteri, int> musteriRepository
    )
    {
        _musteriRepository = musteriRepository;
    }

    public async Task<PagedResultDto<GetMusteriForViewDto>> GetAll(GetAllMusteriInput input)
    {
        var queryable = _musteriRepository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                e => e.Ad.ToUpper().Contains(input.Filter.ToUpper()) ||
                     e.Soyad.ToUpper().Contains(input.Filter.ToUpper()) ||
                     e.Sehir.ToUpper().Contains(input.Filter.ToUpper()));
        
        var pagedAndFiltered = queryable
            .OrderBy(input.Sorting ?? "id desc")
            .PageBy(input);

        var result = from entity in pagedAndFiltered

            select new GetMusteriForViewDto
            {
                Musteri = ObjectMapper.Map<MusteriDto>(entity),
            };

        var totalCount = await queryable.CountAsync();

        return new PagedResultDto<GetMusteriForViewDto>(
            totalCount,
            await result.ToListAsync()
        );
    }

    public async Task<GetMusteriForViewDto> GetMusteriForView(EntityDto input)
    {
        var entity = await _musteriRepository.GetAsync(input.Id);

        var output = new GetMusteriForViewDto
        {
            Musteri = ObjectMapper.Map<MusteriDto>(entity),
        };

        return output;
    }

    public async Task<GetMusteriForEditOutput> GetMusteriForEdit(EntityDto input)
    {
        var output = await _musteriRepository.GetAll()
            .Where(e => e.Id == input.Id)
            .Select(entity => new GetMusteriForEditOutput
            {
                Musteri = ObjectMapper.Map<CreateOrEditMusteriDto>(entity),
            }).FirstOrDefaultAsync();

        return output;
    }

    public async Task CreateOrEdit(CreateOrEditMusteriDto input)
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

    private async Task Create(CreateOrEditMusteriDto input)
    {
        var entity = ObjectMapper.Map<Musteri>(input);
        
        await _musteriRepository.InsertAsync(entity);
    }

    private async Task Update(CreateOrEditMusteriDto input)
    {
        var entity = await _musteriRepository.FirstOrDefaultAsync(input.Id.Value);

        ObjectMapper.Map(input, entity);
    }

    public async Task Delete(EntityDto input)
    {
        await _musteriRepository.DeleteAsync(input.Id);
    }
}