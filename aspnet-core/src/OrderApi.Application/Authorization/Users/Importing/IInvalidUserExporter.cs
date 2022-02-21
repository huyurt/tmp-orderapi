using System.Collections.Generic;
using OrderApi.Authorization.Users.Importing.Dto;
using OrderApi.Dto;

namespace OrderApi.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
