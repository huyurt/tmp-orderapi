using System.Collections.Generic;
using OrderApi.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace OrderApi.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
