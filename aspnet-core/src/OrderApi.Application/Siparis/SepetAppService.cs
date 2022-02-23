using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using OrderApi.Musteri.Dtos.Musteri;
using OrderApi.Siparis.Dtos;
using OrderApi.Siparis.Dtos.Sepet;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis;

public class SepetAppService : OrderApiAppServiceBase, ISepetAppService
{
    private readonly IRepository<Sepet> _sepetRepository;
    private readonly IRepository<SepetUrun> _sepetUrunRepository;
    private readonly IRepository<Musteri.Musteri> _musteriRepository;

    public SepetAppService(
        IRepository<Sepet> sepetRepository,
        IRepository<SepetUrun> sepetUrunRepository,
        IRepository<Musteri.Musteri> musteriRepository
    )
    {
        _sepetRepository = sepetRepository;
        _sepetUrunRepository = sepetUrunRepository;
        _musteriRepository = musteriRepository;
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

    public async Task TestVerisiOlustur(int musteriAdet, int sepetAdet)
    {
        var sehirler = new List<string>
            { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };

        var musteriler = new List<Musteri.Musteri>();
        for (int i = 0; i < musteriAdet; i++)
        {
            var musteri = new Musteri.Musteri
            {
                Ad = RandomString(5),
                Soyad = RandomString(5),
                Sehir = sehirler[random.Next(0, sehirler.Count)],
            };
            
            musteriler.Add(musteri);
        }
        
        for (int i = 0; i < sepetAdet; i++)
        {
            var sepet = new Sepet
            {
                SepetUrunler = GenerateSepetUrun(random.Next(1, 6)),
            };
            
            var musteri = musteriler[random.Next(0, musteriler.Count)];
            
            musteri.Sepetler.Add(sepet);
        }

        foreach (var musteri in musteriler)
        {
            _musteriRepository.Insert(musteri);
        }
    }

    private List<SepetUrun> GenerateSepetUrun(int count)
    {
        var sepetUrunler = new List<SepetUrun>();

        for (int i = 0; i < count; i++)
        {
            var sepetUrun = new SepetUrun
            {
                 Aciklama = RandomString(random.Next(5, 200)),
                 Tutar = random.Next(100, 1001),
            };

            sepetUrunler.Add(sepetUrun);
        }

        return sepetUrunler;
    }
    
    private static Random random = new Random();

    public static string RandomString(int length)
    {
        const string chars = "ABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    

    public async Task<List<DtoSehirAnaliz>> SehirBazliAnalizYap()
    {
        var sehirler = await _musteriRepository.GetAll()
            .GroupBy(m => m.Sehir)
            .Select(x => new DtoSehirAnaliz {
                SehirAdi = x.Key
            })
            .ToListAsync();

        foreach (var sehir in sehirler)
        {
            sehir.SepetAdet = await GetSepetCountBySehir(sehir.SehirAdi);
            sehir.ToplamTutar = await GetSepetUrunTotalBySehir(sehir.SehirAdi);
        }

        sehirler = sehirler.OrderByDescending(x => x.SepetAdet).ToList();

        var totalSepetCount = sehirler.Sum(x => x.SepetAdet);
        var sepetTutar = sehirler.Sum(x => x.ToplamTutar);
        
        
        return sehirler;
    }

    private async Task<int> GetSepetCountBySehir(string sehir)
    {
        return await _sepetRepository.GetAll()
            .Where(x => x.MusteriFk.Sehir == sehir)
            .CountAsync();
    }

    private async Task<decimal> GetSepetUrunTotalBySehir(string sehir)
    {
        return await _sepetUrunRepository.GetAll()
            .Where(x => x.SepetFk.MusteriFk.Sehir == sehir)
            .SumAsync(x => x.Tutar);
    }
}