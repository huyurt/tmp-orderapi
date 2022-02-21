using System.Collections.Generic;
using MvvmHelpers;
using OrderApi.Models.NavigationMenu;

namespace OrderApi.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}