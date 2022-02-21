using System.ComponentModel.DataAnnotations;

namespace OrderApi.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}