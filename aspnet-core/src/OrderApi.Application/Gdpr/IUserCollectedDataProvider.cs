using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using OrderApi.Dto;

namespace OrderApi.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
