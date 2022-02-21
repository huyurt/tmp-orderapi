using System.Collections.Generic;
using OrderApi.Authorization.Users.Dto;
using OrderApi.Dto;

namespace OrderApi.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}