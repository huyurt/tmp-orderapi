using System.ComponentModel.DataAnnotations;

namespace OrderApi.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}