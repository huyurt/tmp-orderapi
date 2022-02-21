using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using OrderApi.Musteri.Dtos.Musteri;
using OrderApi.Siparis.Dtos.Sepet;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis;

public class SepetAppService : OrderApiAppServiceBase, ISepetAppService
{
    private readonly IRepository<Sepet> _sepetRepository;

    public SepetAppService(
        IRepository<Sepet> sepetRepository
    )
    {
        _sepetRepository = sepetRepository;
    }

    public async Task<PagedResultDto<GetSepetForViewDto>> GetAll(GetAllSepetInput input)
    {
        var queryable = _sepetRepository.GetAll()
            .Include(e => e.MusteriFk)
            .Include(e => e.SepetUrunler)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                e => e.MusteriFk.Ad.ToUpper().Contains(input.Filter.ToUpper()) ||
                     e.MusteriFk.Soyad.ToUpper().Contains(input.Filter.ToUpper()) ||
                     e.MusteriFk.Sehir.ToUpper().Contains(input.Filter.ToUpper()) ||
                     e.SepetUrunler.Any(s => s.Aciklama.ToUpper().Contains(input.Filter.ToUpper())));
        
        var pagedAndFiltered = queryable
            .OrderBy(input.Sorting ?? "id desc")
            .PageBy(input);

        var result = from entity in pagedAndFiltered

            select new GetSepetForViewDto
            {
                Sepet = ObjectMapper.Map<SepetDto>(entity),
                Musteri = ObjectMapper.Map<MusteriDto>(entity.MusteriFk),
                SepetUrunler = ObjectMapper.Map<List<SepetUrunDto>>(entity.SepetUrunler),
            };

        var totalCount = await queryable.CountAsync();

        return new PagedResultDto<GetSepetForViewDto>(
            totalCount,
            await result.ToListAsync()
        );
    }

    public async Task<GetSepetForViewDto> GetSepetForView(EntityDto input)
    {
        var entity = await _sepetRepository.GetAll()
            .Include(e => e.MusteriFk)
            .Include(e => e.SepetUrunler)
            .FirstOrDefaultAsync(e => e.Id == input.Id);

        var output = new GetSepetForViewDto
        {
            Sepet = ObjectMapper.Map<SepetDto>(entity),
            Musteri = ObjectMapper.Map<MusteriDto>(entity.MusteriFk),
            SepetUrunler = ObjectMapper.Map<List<SepetUrunDto>>(entity.SepetUrunler),
        };

        return output;
    }

    public async Task<GetSepetForEditOutput> GetSepetForEdit(EntityDto input)
    {
        var output = await _sepetRepository.GetAll()
            .Include(e => e.SepetUrunler)
            .Where(e => e.Id == input.Id)
            .Select(entity => new GetSepetForEditOutput
            {
                Sepet = ObjectMapper.Map<CreateOrEditSepetDto>(entity),
            }).FirstOrDefaultAsync();

        return output;
    }

    public async Task CreateOrEdit(CreateOrEditSepetDto input)
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

    private async Task Create(CreateOrEditSepetDto input)
    {
        var entity = ObjectMapper.Map<Sepet>(input);
        
        await _sepetRepository.InsertAsync(entity);
    }

    private async Task Update(CreateOrEditSepetDto input)
    {
        var entity = await _sepetRepository.GetAll()
            .Include(e => e.SepetUrunler)
            .FirstOrDefaultAsync(e => e.Id == input.Id.Value);

        entity.SepetUrunler.Where(su => !input.SepetUrunler?.Any(i => i.Id == su.Id) ?? false).ToList()
            .ForEach(su => entity.SepetUrunler.Remove(su));

        ObjectMapper.Map(input, entity);
    }

    public async Task Delete(EntityDto input)
    {
        await _sepetRepository.DeleteAsync(input.Id);
    }
}