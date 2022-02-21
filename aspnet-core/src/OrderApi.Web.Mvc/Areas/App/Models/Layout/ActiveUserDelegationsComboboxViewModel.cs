using System.Collections.Generic;
using OrderApi.Authorization.Delegation;
using OrderApi.Authorization.Users.Delegation.Dto;

namespace OrderApi.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
